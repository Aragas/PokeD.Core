using System;

using Aragas.Core.Data;
using Aragas.Core.Extensions;
using Aragas.Core.Interfaces;

using static Aragas.Core.Extensions.PacketExtensions;

namespace PokeD.Core.Data.Structs
{
    public class PlayerDatabase
    {
        public string Name;
        public ulong GameJoltID;
        public string LastIP;
        public DateTime LastSeen;

        public PlayerDatabase FromReader(IPacketDataReader reader)
        {
            Name = reader.Read(Name);
            GameJoltID = reader.Read(GameJoltID);
            LastIP = reader.Read(LastIP);
            LastSeen = reader.Read(LastSeen);

            return this;
        }

        public void ToStream(IPacketStream stream)
        {
            stream.Write(Name);
            stream.Write(GameJoltID);
            stream.Write(LastIP);
            stream.Write(LastSeen);
        }
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
            var length = reader.Read<VarInt>();

            var value = new PlayerDatabaseList();
            for (var i = 0; i < length; i++)
                value[i] = new PlayerDatabase().FromReader(reader);

            return value;
        }

        public void ToStream(IPacketStream stream)
        {
            stream.Write(new VarInt(Length));

            foreach (var entry in _entries)
            {
                stream.Write(entry.Name);
                stream.Write(entry.GameJoltID);
                stream.Write(entry.LastIP);
                stream.Write(entry.LastSeen);
            }
        }
    }
}