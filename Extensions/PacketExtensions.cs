using System;

using Aragas.Core.Data;
using Aragas.Core.IO;

using PokeD.Core.Data.PokeD.Monster;
using PokeD.Core.Data.PokeD.Monster.Data;
using PokeD.Core.Data.PokeD.Monster.Interfaces;
using PokeD.Core.Data.PokeD.Structs;
using PokeD.Core.Data.PokeD.Trainer;
using PokeD.Core.Data.PokeD.Trainer.Interfaces;
using PokeD.Core.Data.SCON;
using PokeD.Core.Packets.PokeD.Overworld.Map;

using static Aragas.Core.IO.PacketStream;
using static Aragas.Core.IO.PacketDataReader;

namespace PokeD.Core.Extensions
{
    public static class PacketExtensions
    {
        private static void Extend<T>(Func<PacketDataReader, int, T> readFunc, Action<PacketStream, T, bool> writeAction)
        {
            ExtendRead(readFunc);
            ExtendWrite(writeAction);
        }

        public static void Init()
        {
            Aragas.Core.Extensions.PacketExtensions.Init();

            Extend<FileHash[]>(ReadFileHashArray, WriteFileHashArray);
            Extend<FileHash>(ReadFileHash, WriteFileHash);

            Extend<ImageResponse[]>(ReadImageResponseArray, WriteImageResponseArray);
            Extend<TileSetResponse[]>(ReadTileSetResponseArray, WriteTileSetResponseArray);
            Extend<ImageResponse>(ReadImageResponse, WriteImageResponse);
            Extend<TileSetResponse>(ReadTileSetResponse, WriteTileSetResponse);

            Extend<MonsterMove>(ReadMonsterMove, WriteMonsterMove);
            Extend<MonsterMoves>(ReadMonsterMoves, WriteMonsterMoves);
            Extend<MonsterStats>(ReadMonsterStats, WriteMonsterStats);
            Extend<MonsterInstanceData>(ReadMonsterInstanceData, WriteMonsterInstanceData);
            
            Extend<IMonsterBaseInfo>(ReadIMonsterBaseInfo, WriteIMonsterBaseInfo);
            Extend<IOpponentTeam>(ReadIOpponentTeam, WriteIOpponentTeam);
            
            Extend<MetaSwitch>(ReadMetaSwitch, WriteMetaSwitch);
            Extend<MetaPosition>(ReadMetaPosition, WriteMetaPosition);
            Extend<MetaAttack>(ReadMetaAttack, WriteMetaAttack);
            Extend<MetaItem>(ReadMetaItem, WriteMetaItem);
            //Extend<BattleState>(ReadBattleState, WriteBattleState);
            
            Extend<Ban>(ReadBan, WriteBan);
            Extend<Log>(ReadLog, WriteLog);
            Extend<PlayerDatabase>(ReadPlayerDatabase, WritePlayerDatabase);
            Extend<PlayerInfo>(ReadPlayerInfo, WritePlayerInfo);

            Extend<Ban[]>(ReadBanArray, WriteBanArray);
            Extend<Log[]>(ReadLogArray, WriteLogArray);
            Extend<PlayerDatabase[]>(ReadPlayerDatabaseArray, WritePlayerDatabaseArray);
            Extend<PlayerInfo[]>(ReadPlayerInfoArray, WritePlayerInfoArray);
        }


        private static void WriteFileHashArray(PacketStream stream, FileHash[] value, bool writeDefaultLength = true)
        {
            stream.Write(new VarInt(value.Length));

            foreach (var fileHash in value)
                stream.Write(fileHash);
        }
        private static FileHash[] ReadFileHashArray(PacketDataReader reader, int length = 0)
        {
            if (length == 0)
                length = reader.Read<VarInt>();

            var array = new FileHash[length];

            for (var i = 0; i < length; i++)
                array[i] = ReadFileHash(reader);

            return array;
        }

        private static void WriteFileHash(PacketStream stream, FileHash value, bool writeDefaultLength = true)
        {
            stream.Write(value.Name);
            stream.Write(value.Hash);
        }
        private static FileHash ReadFileHash(PacketDataReader reader, int length = 0)
        {
            return new FileHash() { Name = reader.Read<string>(), Hash = reader.Read<string>() };
        }

        
        private static void WriteImageResponseArray(PacketStream stream, ImageResponse[] value, bool writeDefaultLength = true)
        {
            stream.Write(new VarInt(value.Length));

            foreach (var imageResponse in value)
                stream.Write(imageResponse);
        }
        private static ImageResponse[] ReadImageResponseArray(PacketDataReader reader, int length = 0)
        {
            if (length == 0)
                length = reader.Read<VarInt>();

            var array = new ImageResponse[length];

            for (var i = 0; i < length; i++)
                array[i] = ReadImageResponse(reader);

            return array;
        }

        private static void WriteTileSetResponseArray(PacketStream stream, TileSetResponse[] value, bool writeDefaultLength = true)
        {
            stream.Write(new VarInt(value.Length));

            foreach (var tileSetResponse in value)
                stream.Write(tileSetResponse);
        }
        private static TileSetResponse[] ReadTileSetResponseArray(PacketDataReader reader, int length = 0)
        {
            if (length == 0)
                length = reader.Read<VarInt>();

            var array = new TileSetResponse[length];

            for (var i = 0; i < length; i++)
                array[i] = ReadTileSetResponse(reader);

            return array;
        }

        private static void WriteImageResponse(PacketStream stream, ImageResponse value, bool writeDefaultLength = true)
        {
            stream.Write(value.Name);
            stream.Write(value.ImageData);
        }
        private static ImageResponse ReadImageResponse(PacketDataReader reader, int length = 0)
        {
            return new ImageResponse() { Name = reader.Read<string>(), ImageData = reader.Read<byte[]>() };
        }

        private static void WriteTileSetResponse(PacketStream stream, TileSetResponse value, bool writeDefaultLength = true)
        {
            stream.Write(value.Name);
            stream.Write(value.TileSetData);
        }
        private static TileSetResponse ReadTileSetResponse(PacketDataReader reader, int length = 0)
        {
            return new TileSetResponse() { Name = reader.Read<string>(), TileSetData = reader.Read<string>() };
        }


        #region MonsterInstanceData

        private static void WriteMonsterMove(PacketStream stream, MonsterMove value, bool writeDefaultLength = true)
        {
            stream.Write(value.ID);
            stream.Write(value.PPUPs);
        }
        private static MonsterMove ReadMonsterMove(PacketDataReader reader, int length = 0)
        {
            return new MonsterMove(
                reader.Read<int>(),
                reader.Read<int>());
        }

        private static void WriteMonsterMoves(PacketStream stream, MonsterMoves value, bool writeDefaultLength = true)
        {
            stream.Write(value.Move_0);
            stream.Write(value.Move_1);
            stream.Write(value.Move_2);
            stream.Write(value.Move_3);
        }
        private static MonsterMoves ReadMonsterMoves(PacketDataReader reader, int length = 0)
        {
            return new MonsterMoves(
                reader.Read<MonsterMove>(),
                reader.Read<MonsterMove>(),
                reader.Read<MonsterMove>(),
                reader.Read<MonsterMove>());
        }

        private static void WriteMonsterStats(PacketStream stream, MonsterStats value, bool writeDefaultLength = true)
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

        private static void WriteMonsterCatchInfo(PacketStream stream, MonsterCatchInfo value, bool writeDefaultLength = true)
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

        private static void WriteMonsterInstanceData(PacketStream stream, MonsterInstanceData value, bool writeDefaultLength = true)
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

        
        private static void WriteIMonsterBaseInfo(PacketStream stream, IMonsterBaseInfo value, bool writeDefaultLength = true)
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

        private static void WriteIOpponentTeam(PacketStream stream, IOpponentTeam value, bool writeDefaultLength = true)
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


        private static void WriteMetaSwitch(PacketStream stream, MetaSwitch value, bool writeDefaultLength = true) { stream.Write(value.Meta); }
        private static MetaSwitch ReadMetaSwitch(PacketDataReader reader, int length = 0) => new MetaSwitch(reader.Read<byte>());

        private static void WriteMetaPosition(PacketStream stream, MetaPosition value, bool writeDefaultLength = true) { stream.Write(value.Meta); }
        private static MetaPosition ReadMetaPosition(PacketDataReader reader, int length = 0) => new MetaPosition(reader.Read<long>());

        //private static void WriteBattleState(PacketStream stream, BattleState value, bool writeDefaultLength = true) { stream.Write(value.Meta); }
        //private static BattleState ReadBattleState(PacketDataReader reader, int length = 0) => new BattleState();

        private static void WriteMetaAttack(PacketStream stream, MetaAttack value, bool writeDefaultLength = true) { stream.Write(value.Meta); }
        private static MetaAttack ReadMetaAttack(PacketDataReader reader, int length = 0) => new MetaAttack(reader.Read<byte>());

        private static void WriteMetaItem(PacketStream stream, MetaItem value, bool writeDefaultLength = true) { stream.Write(value.Meta); }
        private static MetaItem ReadMetaItem(PacketDataReader reader, int length = 0) => new MetaItem(reader.Read<short>());


        private static void WriteBan(PacketStream stream, Ban value, bool writeDefaultLength = true)
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

        private static void WriteLog(PacketStream stream, Log value, bool writeDefaultLength = true)
        {
            stream.Write(value.LogFileName);
        }
        private static Log ReadLog(PacketDataReader reader, int length = 0)
        {
            var value = new Log();
            value.LogFileName = reader.Read(value.LogFileName);

            return value;
        }

        private static void WritePlayerDatabase(PacketStream stream, PlayerDatabase value, bool writeDefaultLength = true)
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

        private static void WritePlayerInfo(PacketStream stream, PlayerInfo value, bool writeDefaultLength = true)
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


        private static void WriteBanArray(PacketStream stream, Ban[] value, bool writeDefaultLength = true)
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

            for (var i = 0; i < length; i++)
                array[i] = ReadBan(reader);

            return array;
        }

        private static void WriteLogArray(PacketStream stream, Log[] value, bool writeDefaultLength = true)
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

            for (var i = 0; i < length; i++)
                array[i] = ReadLog(reader);

            return array;
        }

        private static void WritePlayerDatabaseArray(PacketStream stream, PlayerDatabase[] value, bool writeDefaultLength = true)
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

            for (var i = 0; i < length; i++)
                array[i] = ReadPlayerDatabase(reader);

            return array;
        }

        private static void WritePlayerInfoArray(PacketStream stream, PlayerInfo[] value, bool writeDefaultLength = true)
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

            for (var i = 0; i < length; i++)
                array[i] = ReadPlayerInfo(reader);

            return array;
        }
    }
}