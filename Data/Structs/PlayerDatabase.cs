using System;

using PokeD.Core.Extensions;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Data.Structs
{
    public class PlayerDatabase
    {
        public string Name { get; set; }
        public ulong GameJoltID { get; set; }
        public string LastIP { get; set; }
        public DateTime LastSeen { get; set; }
    }

    public class PlayerDatabaseList
    {
        public int Length => _entries.Length;

        private PlayerDatabase[] _entries;

        public PlayerDatabaseList(int length = 0)
        {
            _entries = new PlayerDatabase[length];
        }

        public PlayerDatabaseList(params PlayerDatabase[] data)
        {
            _entries = data;
        }

        public PlayerDatabase this[int index]
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

        public static PlayerDatabaseList FromReader(IPacketDataReader reader)
        {
            var length = reader.ReadVarInt();

            var value = new PlayerDatabaseList();
            for (var i = 0; i < length; i++)
                value[i] = new PlayerDatabase
                {
                    Name = reader.ReadString(),
                    GameJoltID = reader.ReadULong(),
                    LastIP = reader.ReadString(),
                    LastSeen = DateTimeExtensions.FromReader(reader)
                };
            
            return value;
        }

        public void ToStream(IPacketStream stream)
        {
            stream.WriteVarInt(Length);

            foreach (var entry in _entries)
            {
                stream.WriteString(entry.Name);
                stream.WriteULong(entry.GameJoltID);
                stream.WriteString(entry.LastIP);
                entry.LastSeen.ToStream(stream);
            }
        }
    }
}