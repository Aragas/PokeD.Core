using System;

using Aragas.Core.Data;
using Aragas.Core.Extensions;
using Aragas.Core.Interfaces;

using static Aragas.Core.Extensions.PacketExtensions;

namespace PokeD.Core.Data.Structs
{
    public class PlayerInfo
    {
        public string Name;
        public long GameJoltID;
        public string IP;
        public ushort Ping;
        public Vector3 Position;
        public string LevelFile;
        public TimeSpan PlayTime;

        public PlayerInfo FromReader(IPacketDataReader reader)
        {
            Name = reader.Read(Name);
            GameJoltID = reader.Read(GameJoltID);
            IP = reader.Read(IP);
            Ping = reader.Read(Ping);
            Position = reader.Read(Position);
            LevelFile = reader.Read(LevelFile);
            PlayTime = reader.Read(PlayTime);

            return this;
        }

        public void ToStream(IPacketStream stream)
        {
            stream.Write(Name);
            stream.Write(GameJoltID);
            stream.Write(IP);
            stream.Write(Ping);
            stream.Write(Position);
            stream.Write(LevelFile);
            stream.Write(PlayTime);
        }
    }

    public class PlayerInfoList
    {
        public int Length => _entries.Length;

        private PlayerInfo[] _entries;

        public PlayerInfoList(int length = 0)
        {
            _entries = new PlayerInfo[length];
        }

        public PlayerInfoList(params PlayerInfo[] data)
        {
            _entries = data;
        }

        public PlayerInfo this[int index]
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

        public static PlayerInfoList FromReader(IPacketDataReader reader)
        {
            var length = reader.Read<VarInt>();

            var value = new PlayerInfoList();
            for (var i = 0; i < length; i++)
                value[i] = new PlayerInfo().FromReader(reader);
            
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