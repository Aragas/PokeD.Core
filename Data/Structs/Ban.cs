using System;

using PokeD.Core.Extensions;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Data.Structs
{
    public class Ban
    {
        public string Name { get; set; }
        public uint GameJoltID { get; set; }
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
                    GameJoltID = reader.ReadUInt(),
                    IP = reader.ReadString(),
                    BanTime = DateTimeExtensions.FromReader(reader),
                    UnBanTime = DateTimeExtensions.FromReader(reader),
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
                stream.WriteUInt(entry.GameJoltID);
                stream.WriteString(entry.IP);
                entry.BanTime.ToStream(stream);
                entry.UnBanTime.ToStream(stream);
                stream.WriteString(entry.Reason);
            }
        }
    }
}