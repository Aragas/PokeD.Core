using System;

using Aragas.Core.Data;
using Aragas.Core.Extensions;
using Aragas.Core.Interfaces;

namespace PokeD.Core.Data.Structs
{
    public class Ban
    {
        public string Name;
        public ulong GameJoltID;
        public string IP;
        public DateTime BanTime;
        public DateTime UnBanTime;
        public string Reason;

        public Ban FromReader(IPacketDataReader reader)
        {
            Name = reader.Read(Name);
            GameJoltID = reader.Read(GameJoltID);
            IP = reader.Read(IP);
            BanTime = reader.Read(BanTime);
            UnBanTime = reader.Read(UnBanTime);
            Reason = reader.Read(Reason);

            return this;
        }

        public void ToStream(IPacketStream stream)
        {
            stream.Write(Name);
            stream.Write(GameJoltID);
            stream.Write(IP);
            stream.Write(BanTime);
            stream.Write(UnBanTime);
            stream.Write(Reason);
        }
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
            VarInt length = 0;
            reader.Read(length);

            var value = new BanList();
            for (var i = 0; i < length; i++)
                value[i] = new Ban().FromReader(reader);
            
            return value;
        }

        public void ToStream(IPacketStream stream)
        {
            stream.Write(new VarInt(Length));

            foreach (var entry in _entries)
            {
                stream.Write(entry.Name);
                stream.Write(entry.GameJoltID);
                stream.Write(entry.IP);
                stream.Write(entry.BanTime);
                stream.Write(entry.UnBanTime);
                stream.Write(entry.Reason);
            }
        }
    }
}