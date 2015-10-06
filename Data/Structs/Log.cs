using System;

using Aragas.Core.Data;
using Aragas.Core.Interfaces;

namespace PokeD.Core.Data.Structs
{
    public class Log
    {
        public string LogFileName;

        public Log FromReader(IPacketDataReader reader)
        {
            LogFileName = reader.Read(LogFileName);

            return this;
        }

        public void ToStream(IPacketStream stream)
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

        public static LogList FromReader(IPacketDataReader reader)
        {
            VarInt length = 0;
            reader.Read(length);

            var value = new LogList();
            for (var i = 0; i < length; i++)
                value[i] = new Log().FromReader(reader);
            
            return value;
        }

        public void ToStream(IPacketStream stream)
        {
            stream.Write(new VarInt(Length));

            foreach (var entry in _entries)
                entry.ToStream(stream);
        }
    }
}