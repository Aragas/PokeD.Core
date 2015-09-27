using System;

using PokeD.Core.Extensions;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Data.Structs
{
    public class Log
    {
        public string LogFileName { get; set; }
    }

    public class LogList
    {
        public int Length => _entries.Length;

        private Log[] _entries;

        public LogList(int length = 0)
        {
            _entries = new Log[length];
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
            var count = reader.ReadVarInt();

            var value = new LogList();
            for (var i = 0; i < count; i++)
                value[i] = new Log
                {
                    LogFileName = reader.ReadString(),
                };
            
            return value;
        }

        public void ToStream(IPacketStream stream)
        {
            stream.WriteVarInt(Length);

            foreach (var entry in _entries)
            {
                stream.WriteString(entry.LogFileName);
            }
        }
    }
}