using System;

using PokeD.Core.Extensions;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Data.Structs
{
    public class Ban
    {
        public string Name { get; set; }
        public ulong GameJoltID { get; set; }
        public string IP { get; set; }
        public DateTime BanTime { get; set; }
        public DateTime UnBanTime { get; set; }
        public string Reason { get; set; }
    }

    public class BanList
    {
        public int Length => _entries.Length;

        private Ban[] _entries;

        public BanList(int length = 0)
        {
            _entries = new Ban[length];
        }

        public BanList(params Ban[] data)
        {
            _entries = data;
        }

        public Ban this[int index]
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

        public static BanList FromReader(IPacketDataReader reader)
        {
            var count = reader.ReadVarInt();

            var value = new BanList();
            for (var i = 0; i < count; i++)
                value[i] = new Ban
                {
                    Name = reader.ReadString(),
                    GameJoltID = reader.ReadULong(),
                    IP = reader.ReadString(),
                    BanTime = reader.ReadDateTime(),
                    UnBanTime = reader.ReadDateTime(),
                    Reason = reader.ReadString()
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
                stream.WriteString(entry.IP);
                stream.WriteDateTime(entry.BanTime);
                stream.WriteDateTime(entry.UnBanTime);
                stream.WriteString(entry.Reason);
            }
        }
    }
}