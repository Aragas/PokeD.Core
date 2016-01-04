using Aragas.Core.Data;
using Aragas.Core.Extensions;
using Aragas.Core.IO;

using PokeD.Core.Data.PokeD;
using PokeD.Core.Data.PokeD.Monster;
using PokeD.Core.Data.PokeD.Trainer;
using PokeD.Core.Data.SCON;

using static Aragas.Core.IO.PacketDataReader;

namespace PokeD.Core.Extensions
{
    public static class PacketExtensions
    {
        public static void Init()
        {
            Aragas.Core.Extensions.PacketExtensions.Init();

            ExtendRead<IMonsterBaseInfo>(ReadIMonsterBaseInfo);
            ExtendRead<IOpponentTeam>(ReadIOpponentTeam);
            
            ExtendRead<MetaSwitch>(ReadMetaSwitch);
            ExtendRead<MetaPosition>(ReadMetaPosition);
            ExtendRead<MetaAttack>(ReadMetaAttack);
            ExtendRead<MetaItem>(ReadMetaItem);
            ExtendRead<BattleState>(ReadMetaItem);
            
            ExtendRead<Ban>(ReadBan);
            ExtendRead<Log>(ReadLog);
            ExtendRead<PlayerDatabase>(ReadPlayerDatabase);
            ExtendRead<PlayerInfo>(ReadPlayerInfo);

            ExtendRead<Ban[]>(ReadBanArray);
            ExtendRead<Log[]>(ReadLogArray);
            ExtendRead<PlayerDatabase[]>(ReadPlayerDatabaseArray);
            ExtendRead<PlayerInfo[]>(ReadPlayerInfoArray);
        }


        public static void Write(this PacketStream stream, IMonsterBaseInfo value)
        {
            stream.Write(value.ID);
            stream.Write(value.DisplayName);
            stream.Write((byte) value.Gender);
            stream.Write(value.Level);
            stream.Write(value.IsShiny);
        }
        private static IMonsterBaseInfo ReadIMonsterBaseInfo(PacketDataReader reader, int length = 0)
        {
            var id = reader.Read<short>();
            var nickname = reader.Read<string>();
            var gender = reader.Read<byte>();
            var level = reader.Read<byte>();
            var isShiny = reader.Read<bool>();

            return new Monster(id, nickname, (MonsterGender) gender, level, isShiny);
        }

        public static void Write(this PacketStream stream, IOpponentTeam value)
        {
            stream.Write((IMonsterBaseInfo) value.Monster_1);
            stream.Write((IMonsterBaseInfo) value.Monster_2);
            stream.Write((IMonsterBaseInfo) value.Monster_3);
            stream.Write((IMonsterBaseInfo) value.Monster_4);
            stream.Write((IMonsterBaseInfo) value.Monster_5);
            stream.Write((IMonsterBaseInfo) value.Monster_6);
        }
        private static IOpponentTeam ReadIOpponentTeam(PacketDataReader reader, int length = 0)
        {
            return new MonsterParty()
            {
                Monster_1 = new Monster(reader.Read<IMonsterBaseInfo>()),
                Monster_2 = new Monster(reader.Read<IMonsterBaseInfo>()),
                Monster_3 = new Monster(reader.Read<IMonsterBaseInfo>()),
                Monster_4 = new Monster(reader.Read<IMonsterBaseInfo>()),
                Monster_5 = new Monster(reader.Read<IMonsterBaseInfo>()),
                Monster_6 = new Monster(reader.Read<IMonsterBaseInfo>()),
            };
        }

        public static void Write(this PacketStream stream, MetaSwitch value) { stream.Write(value.Meta); }
        private static MetaSwitch ReadMetaSwitch(PacketDataReader reader, int length = 0) => new MetaSwitch(reader.Read<byte>());

        public static void Write(this PacketStream stream, MetaPosition value) { stream.Write(value.Meta); }
        private static MetaPosition ReadMetaPosition(PacketDataReader reader, int length = 0) => new MetaPosition(reader.Read<long>());

        //public static void Write(this PacketStream stream, BattleState value) { stream.Write(value.Meta); }
        private static BattleState ReadBattleState(PacketDataReader reader, int length = 0) => new BattleState();

        public static void Write(this PacketStream stream, MetaAttack value) { stream.Write(value.Meta); }
        private static MetaAttack ReadMetaAttack(PacketDataReader reader, int length = 0) => new MetaAttack(reader.Read<byte>());

        public static void Write(this PacketStream stream, MetaItem value) { stream.Write(value.Meta); }
        private static MetaItem ReadMetaItem(PacketDataReader reader, int length = 0) => new MetaItem(reader.Read<short>());


        public static void Write(this PacketStream stream, Ban value)
        {
            stream.Write(value.Name);
            stream.Write(value.GameJoltID);
            stream.Write(value.IP);
            stream.Write(value.BanTime);
            stream.Write(value.UnBanTime);
            stream.Write(value.Reason);
        }
        private static Ban ReadBan(PacketDataReader reader, int length = 0)
        {
            var value = new Ban();
            value.Name = reader.Read(value.Name);
            value.GameJoltID = reader.Read(value.GameJoltID);
            value.IP = reader.Read(value.IP);
            value.BanTime = reader.Read(value.BanTime);
            value.UnBanTime = reader.Read(value.UnBanTime);
            value.Reason = reader.Read(value.Reason);

            return value;
        }

        public static void Write(this PacketStream stream, Log value)
        {
            stream.Write(value.LogFileName);
        }
        private static Log ReadLog(PacketDataReader reader, int length = 0)
        {
            var value = new Log();
            value.LogFileName = reader.Read(value.LogFileName);

            return value;
        }

        public static void Write(this PacketStream stream, PlayerDatabase value)
        {
            stream.Write(value.Name);
            stream.Write(value.GameJoltID);
            stream.Write(value.LastIP);
            stream.Write(value.LastSeen);
        }
        private static PlayerDatabase ReadPlayerDatabase(PacketDataReader reader, int length = 0)
        {
            var value = new PlayerDatabase();
            value.Name = reader.Read(value.Name);
            value.GameJoltID = reader.Read(value.GameJoltID);
            value.LastIP = reader.Read(value.LastIP);
            value.LastSeen = reader.Read(value.LastSeen);

            return value;
        }

        public static void Write(this PacketStream stream, PlayerInfo value)
        {
            stream.Write(value.Name);
            stream.Write(value.GameJoltID);
            stream.Write(value.IP);
            stream.Write(value.Ping);
            stream.Write(value.Position);
            stream.Write(value.LevelFile);
            stream.Write(value.PlayTime);
        }
        private static PlayerInfo ReadPlayerInfo(PacketDataReader reader, int length = 0)
        {
            var value = new PlayerInfo();
            value.Name = reader.Read(value.Name);
            value.GameJoltID = reader.Read(value.GameJoltID);
            value.IP = reader.Read(value.IP);
            value.Ping = reader.Read(value.Ping);
            value.Position = reader.Read(value.Position);
            value.LevelFile = reader.Read(value.LevelFile);
            value.PlayTime = reader.Read(value.PlayTime);

            return value;
        }


        public static void Write(this PacketStream stream, Ban[] value)
        {
            stream.Write(new VarInt(value.Length));

            foreach (var playerInfo in value)
                stream.Write(playerInfo);
        }
        private static Ban[] ReadBanArray(PacketDataReader reader, int length = 0)
        {
            if (length == 0)
                length = reader.Read<VarInt>();

            var array = new Ban[length];

            for (int i = 0; i < length; i++)
                array[i] = ReadBan(reader);

            return array;
        }

        public static void Write(this PacketStream stream, Log[] value)
        {
            stream.Write(new VarInt(value.Length));

            foreach (var playerInfo in value)
                stream.Write(playerInfo);
        }
        private static Log[] ReadLogArray(PacketDataReader reader, int length = 0)
        {
            if (length == 0)
                length = reader.Read<VarInt>();

            var array = new Log[length];

            for (int i = 0; i < length; i++)
                array[i] = ReadLog(reader);

            return array;
        }

        public static void Write(this PacketStream stream, PlayerDatabase[] value)
        {
            stream.Write(new VarInt(value.Length));

            foreach (var playerInfo in value)
                stream.Write(playerInfo);
        }
        private static PlayerDatabase[] ReadPlayerDatabaseArray(PacketDataReader reader, int length = 0)
        {
            if (length == 0)
                length = reader.Read<VarInt>();

            var array = new PlayerDatabase[length];

            for (int i = 0; i < length; i++)
                array[i] = ReadPlayerDatabase(reader);

            return array;
        }

        public static void Write(this PacketStream stream, PlayerInfo[] value)
        {
            stream.Write(new VarInt(value.Length));

            foreach (var playerInfo in value)
                stream.Write(playerInfo);
        }
        private static PlayerInfo[] ReadPlayerInfoArray(PacketDataReader reader, int length = 0)
        {
            if (length == 0)
                length = reader.Read<VarInt>();

            var array = new PlayerInfo[length];

            for (int i = 0; i < length; i++)
                array[i] = ReadPlayerInfo(reader);

            return array;
        }
    }
}
