using System.Linq;

using Aragas.Core.Data;
using Aragas.Core.Extensions;
using Aragas.Core.IO;

using PokeD.Core.Data.PokeD.Battle;
using PokeD.Core.Data.PokeD.Monster;
using PokeD.Core.Data.PokeD.Monster.Data;
using PokeD.Core.Data.PokeD.Monster.Interfaces;
using PokeD.Core.Data.PokeD.Structs;
using PokeD.Core.Data.PokeD.Trainer;
using PokeD.Core.Data.PokeD.Trainer.Interfaces;
using PokeD.Core.Data.SCON;

using static Aragas.Core.IO.PacketDataReader;

namespace PokeD.Core.Extensions
{
    public static class PacketExtensions
    {
        public static void Init()
        {
            Aragas.Core.Extensions.PacketExtensions.Init();

            ExtendRead<Move>(ReadMove);
            ExtendRead<MonsterMoves>(ReadMonsterMoves);
            ExtendRead<MonsterStats>(ReadMonsterStats);
            ExtendRead<MonsterInstanceData>(ReadMonsterInstanceData);
            
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


        #region MonsterInstanceData

        public static void Write(this PacketStream stream, Move value)
        {
            stream.Write(value.ID);
            stream.Write(value.PPUPs);
        }
        private static Move ReadMove(PacketDataReader reader, int length = 0)
        {
            return new Move(
                reader.Read<int>(),
                reader.Read<int>());
        }

        public static void Write(this PacketStream stream, MonsterMoves value)
        {
            stream.Write(value.Move_0);
            stream.Write(value.Move_1);
            stream.Write(value.Move_2);
            stream.Write(value.Move_3);
        }
        private static MonsterMoves ReadMonsterMoves(PacketDataReader reader, int length = 0)
        {
            return new MonsterMoves(
                reader.Read<Move>(),
                reader.Read<Move>(),
                reader.Read<Move>(),
                reader.Read<Move>());
        }

        public static void Write(this PacketStream stream, MonsterStats value)
        {
            stream.Write(value.HP);
            stream.Write(value.Attack);
            stream.Write(value.Defense);
            stream.Write(value.SpecialAttack);
            stream.Write(value.SpecialDefense);
            stream.Write(value.Speed);
        }
        private static MonsterStats ReadMonsterStats(PacketDataReader reader, int length = 0)
        {
            return new MonsterStats(
                reader.Read<short>(),
                reader.Read<short>(),
                reader.Read<short>(),
                reader.Read<short>(),
                reader.Read<short>(),
                reader.Read<short>());
        }

        public static void Write(this PacketStream stream, MonsterCatchInfo value)
        {
            stream.Write(value.Method);
            stream.Write(value.Location);
            stream.Write(value.TrainerName);
            stream.Write(value.TrainerID);
            stream.Write(value.PokeballID);
            stream.Write(value.Nickname);
        }
        private static MonsterCatchInfo ReadMonsterCatchInfo(PacketDataReader reader, int length = 0)
        {
            return new MonsterCatchInfo
            {
                Method = reader.Read<string>(),
                Location = reader.Read<string>(),
                TrainerName = reader.Read<string>(),
                TrainerID = reader.Read<ushort>(),
                PokeballID = reader.Read<byte>(),
                Nickname = reader.Read<string>()
            };
        }

        public static void Write(this PacketStream stream, MonsterInstanceData value)
        {
            stream.Write(value.Species);
            stream.Write(value.SecretID);
            stream.Write(value.PersonalityValue);
            stream.Write(value.Nature);
            stream.Write(value.CatchInfo);
            stream.Write(value.Experience);
            stream.Write(value.EggSteps);
            stream.Write(value.IV);
            stream.Write(value.EV);
            stream.Write(value.HiddenEV);
            stream.Write(value.CurrentHP);
            stream.Write(value.StatusEffect);
            stream.Write(value.Affection);
            stream.Write(value.Friendship);
            stream.Write(value.Moves);
            stream.Write(value.HeldItem);
        }
        private static MonsterInstanceData ReadMonsterInstanceData(PacketDataReader reader, int length = 0)
        {
            var species = reader.Read<short>();
            var secretId = reader.Read<ushort>();
            var personalityValue = reader.Read<uint>();
            var nature = reader.Read<byte>();

            return new MonsterInstanceData(species, secretId, personalityValue, nature)
            {
                CatchInfo = reader.Read<MonsterCatchInfo>(),
                Experience = reader.Read<int>(),
                EggSteps = reader.Read<int>(),
                IV = reader.Read<MonsterStats>(),
                EV = reader.Read<MonsterStats>(),
                HiddenEV = reader.Read<MonsterStats>(),
                CurrentHP = reader.Read<short>(),
                StatusEffect = reader.Read<short>(),
                Affection = reader.Read<byte>(),
                Friendship = reader.Read<byte>(),
                Moves = reader.Read<MonsterMoves>(),
                HeldItem = reader.Read<short>(),
            };
        }

        #endregion MonsterInstanceData
        
        public static void Write(this PacketStream stream, IMonsterBaseInfo value)
        {
            stream.Write(value.Species);
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

            //return new Monster(id, nickname, (MonsterGender) gender, level, isShiny);
            return null;
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
            stream.Write(value.IP);
            stream.Write(value.BanTime);
            stream.Write(value.UnBanTime);
            stream.Write(value.Reason);
        }
        private static Ban ReadBan(PacketDataReader reader, int length = 0)
        {
            var value = new Ban();
            value.Name = reader.Read(value.Name);
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
            stream.Write(value.LastIP);
            stream.Write(value.LastSeen);
        }
        private static PlayerDatabase ReadPlayerDatabase(PacketDataReader reader, int length = 0)
        {
            var value = new PlayerDatabase();
            value.Name = reader.Read(value.Name);
            value.LastIP = reader.Read(value.LastIP);
            value.LastSeen = reader.Read(value.LastSeen);

            return value;
        }

        public static void Write(this PacketStream stream, PlayerInfo value)
        {
            stream.Write(value.Name);
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
