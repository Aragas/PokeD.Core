using System;

using Aragas.Core.Data;
using Aragas.Core.IO;

namespace PokeD.Core.Data.Structs
{
    public class Log
    {
        public string LogFileName;

        public Log FromReader(PacketDataReader reader)
        {
            LogFileName = reader.Read(LogFileName);

            return this;
        }

        public void ToStream(PacketStream stream)
        {
            stream.Write(LogFileName);
        }
    }

    public class LogList
    {
        public int Length => _entries.Length;

        private Log[] _entries;

        public LogList(int length = 0)
        {
            _entries = new Log[length];
        }

        public LogList(params Log[] data)
        {
            _entries = data;
        }

        public Log this[int index]
        {
            get
            {
                if (_entries.Length < index + 1)
                    return null;

                return _entries[index];
            }
            set
            {
                if (_entries.Length < index + 1)
                    Array.Resize(ref _entries, index + 1);

                _entries[index] = value;
            }
        }

        public static LogList FromReader(PacketDataReader reader)
        {
            var length = reader.Read<VarInt>();

            var value = new LogList();
            for (var i = 0; i < length; i++)
                value[i] = new Log().FromReader(reader);
            
            return value;
        }

        public void ToStream(PacketStream stream)
        {
            stream.Write(new VarInt(Length));

            foreach (var entry in _entries)
                entry.ToStream(stream);
        }
    }
}