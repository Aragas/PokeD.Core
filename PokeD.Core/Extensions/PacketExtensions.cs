using System;

using Aragas.Network.Data;
using Aragas.Network.IO;

using PokeD.BattleEngine.Battle;
using PokeD.BattleEngine.Monster.Data;
using PokeD.BattleEngine.Trainer.Data;
using PokeD.Core.Data.PokeD;
using PokeD.Core.Data.PokeD.Structs;
using PokeD.Core.Data.SCON;
using PokeD.Core.Packets.PokeD.Overworld.Map;

using static Aragas.Network.IO.PacketSerializer;
using static Aragas.Network.IO.PacketDeserialiser;

namespace PokeD.Core.Extensions
{
    public static class PacketExtensions
    {
        private static void Extend<T>(Func<PacketDeserialiser, int, T> readFunc, Action<PacketSerializer, T, bool> writeAction)
        {
            ExtendRead(readFunc);
            ExtendWrite(writeAction);
        }

        public static void Init()
        {
            Aragas.Network.Extensions.PacketExtensions.Init();

            Extend<FileHash[]>(ReadFileHashArray, WriteFileHashArray);
            Extend<FileHash>(ReadFileHash, WriteFileHash);

            Extend<ImageResponse[]>(ReadImageResponseArray, WriteImageResponseArray);
            Extend<TileSetResponse[]>(ReadTileSetResponseArray, WriteTileSetResponseArray);
            Extend<ImageResponse>(ReadImageResponse, WriteImageResponse);
            Extend<TileSetResponse>(ReadTileSetResponse, WriteTileSetResponse);

            Extend<Attack>(ReadAttack, WriteAttack);
            //Extend<MonsterMoves>(ReadMonsterMoves, WriteMonsterMoves);
            Extend<Stats>(ReadStats, WriteStats);
            Extend<Monster>(ReadMonster, WriteMonster);

            //Extend<IMonsterBaseInfo>(ReadIMonsterBaseInfo, WriteIMonsterBaseInfo);

            Extend<CatchInfo>(ReadCatchInfo, WriteCatchInfo);

            Extend<MonsterTeam>(ReadMonsterTeam, WriteMonsterTeam);
            //Extend<MonsterParty>(ReadMonsterParty, WriteIOpponentTeam);
            
            Extend<MetaSwitch>(ReadMetaSwitch, WriteMetaSwitch);
            Extend<MetaPosition>(ReadMetaPosition, WriteMetaPosition);
            Extend<MetaAttack>(ReadMetaAttack, WriteMetaAttack);
            Extend<MetaItem>(ReadMetaItem, WriteMetaItem);
            Extend<BattleState>(ReadBattleState, WriteBattleState);
            
            Extend<Ban>(ReadBan, WriteBan);
            Extend<Log>(ReadLog, WriteLog);
            Extend<PlayerDatabase>(ReadPlayerDatabase, WritePlayerDatabase);
            Extend<PlayerInfo>(ReadPlayerInfo, WritePlayerInfo);

            Extend<Ban[]>(ReadBanArray, WriteBanArray);
            Extend<Log[]>(ReadLogArray, WriteLogArray);
            Extend<PlayerDatabase[]>(ReadPlayerDatabaseArray, WritePlayerDatabaseArray);
            Extend<PlayerInfo[]>(ReadPlayerInfoArray, WritePlayerInfoArray);
        }


        private static void WriteFileHashArray(PacketSerializer serializer, FileHash[] value, bool writeDefaultLength = true)
        {
            serializer.Write(new VarInt(value.Length));

            foreach (var fileHash in value)
                serializer.Write(fileHash);
        }
        private static FileHash[] ReadFileHashArray(PacketDeserialiser deserialiser, int length = 0)
        {
            if (length == 0)
                length = deserialiser.Read<VarInt>();

            var array = new FileHash[length];

            for (var i = 0; i < length; i++)
                array[i] = ReadFileHash(deserialiser);

            return array;
        }

        private static void WriteFileHash(PacketSerializer serializer, FileHash value, bool writeDefaultLength = true)
        {
            serializer.Write(value.Name);
            serializer.Write(value.Hash);
        }
        private static FileHash ReadFileHash(PacketDeserialiser deserialiser, int length = 0)
        {
            return new FileHash() { Name = deserialiser.Read<string>(), Hash = deserialiser.Read<string>() };
        }

        
        private static void WriteImageResponseArray(PacketSerializer serializer, ImageResponse[] value, bool writeDefaultLength = true)
        {
            serializer.Write(new VarInt(value.Length));

            foreach (var imageResponse in value)
                serializer.Write(imageResponse);
        }
        private static ImageResponse[] ReadImageResponseArray(PacketDeserialiser deserialiser, int length = 0)
        {
            if (length == 0)
                length = deserialiser.Read<VarInt>();

            var array = new ImageResponse[length];

            for (var i = 0; i < length; i++)
                array[i] = ReadImageResponse(deserialiser);

            return array;
        }

        private static void WriteTileSetResponseArray(PacketSerializer serializer, TileSetResponse[] value, bool writeDefaultLength = true)
        {
            serializer.Write(new VarInt(value.Length));

            foreach (var tileSetResponse in value)
                serializer.Write(tileSetResponse);
        }
        private static TileSetResponse[] ReadTileSetResponseArray(PacketDeserialiser deserialiser, int length = 0)
        {
            if (length == 0)
                length = deserialiser.Read<VarInt>();

            var array = new TileSetResponse[length];

            for (var i = 0; i < length; i++)
                array[i] = ReadTileSetResponse(deserialiser);

            return array;
        }

        private static void WriteImageResponse(PacketSerializer serializer, ImageResponse value, bool writeDefaultLength = true)
        {
            serializer.Write(value.Name);
            serializer.Write(value.ImageData);
        }
        private static ImageResponse ReadImageResponse(PacketDeserialiser deserialiser, int length = 0)
        {
            return new ImageResponse() { Name = deserialiser.Read<string>(), ImageData = deserialiser.Read<byte[]>() };
        }

        private static void WriteTileSetResponse(PacketSerializer serializer, TileSetResponse value, bool writeDefaultLength = true)
        {
            serializer.Write(value.Name);
            serializer.Write(value.TileSetData);
        }
        private static TileSetResponse ReadTileSetResponse(PacketDeserialiser deserialiser, int length = 0)
        {
            return new TileSetResponse() { Name = deserialiser.Read<string>(), TileSetData = deserialiser.Read<string>() };
        }


        #region MonsterInstanceData

        private static void WriteAttack(PacketSerializer serializer, Attack value, bool writeDefaultLength = true)
        {
            serializer.Write(value.StaticData.ID);
            serializer.Write(value.PPCurrent);
            serializer.Write(value.PPUps);
        }
        private static Attack ReadAttack(PacketDeserialiser deserialiser, int length = 0)
        {
            return new Attack(deserialiser.Read<short>(), deserialiser.Read<byte>(), deserialiser.Read<byte>());
        }

        /*
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
        */

        private static void WriteStats(PacketSerializer serializer, Stats value, bool writeDefaultLength = true)
        {
            serializer.Write(value.HP);
            serializer.Write(value.Attack);
            serializer.Write(value.Defense);
            serializer.Write(value.SpecialAttack);
            serializer.Write(value.SpecialDefense);
            serializer.Write(value.Speed);
        }
        private static Stats ReadStats(PacketDeserialiser deserialiser, int length = 0)
        {
            return new Stats(
                deserialiser.Read<short>(),
                deserialiser.Read<short>(),
                deserialiser.Read<short>(),
                deserialiser.Read<short>(),
                deserialiser.Read<short>(),
                deserialiser.Read<short>());
        }

        private static void WriteCatchInfo(PacketSerializer serializer, CatchInfo value, bool writeDefaultLength = true)
        {
            serializer.Write(value.Method);
            serializer.Write(value.Location);
            serializer.Write(value.TrainerName);
            serializer.Write(value.TrainerID);
            serializer.Write(value.PokeballID);
            serializer.Write(value.Nickname);
        }
        private static CatchInfo ReadCatchInfo(PacketDeserialiser deserialiser, int length = 0)
        {
            return new CatchInfo
            {
                Method = deserialiser.Read<string>(),
                Location = deserialiser.Read<string>(),
                TrainerName = deserialiser.Read<string>(),
                TrainerID = deserialiser.Read<ushort>(),
                PokeballID = deserialiser.Read<byte>(),
                Nickname = deserialiser.Read<string>()
            };
        }

        private static void WriteMonster(PacketSerializer serializer, Monster value, bool writeDefaultLength = true)
        {
            /*
            stream.Write(value.StaticData.ID);
            stream.Write(value.SecretID);
            stream.Write(value.PersonalityValue);
            stream.Write(value.Nature);
            stream.Write(value.CatchInfo);
            stream.Write(value.Experience);
            stream.Write(value.EggSteps);
            stream.Write(value.IV);
            stream.Write(value.EV);
            stream.Write(value.CurrentHP);
            stream.Write(value.StatusEffect);
            stream.Write(value.Affection);
            stream.Write(value.Friendship);
            stream.Write(value.Moves);
            stream.Write(value.HeldItem);
            */
        }
        private static Monster ReadMonster(PacketDeserialiser deserialiser, int length = 0)
        {
            return null;
            /*
            var species = reader.Read<short>();
            var secretID = reader.Read<ushort>();
            var personalityValue = reader.Read<uint>();
            var nature = reader.Read<byte>();

            return new Monster(species, secretID, personalityValue, nature)
            {
                CatchInfo = reader.Read<CatchInfo>(),
                Experience = reader.Read<int>(),
                EggSteps = reader.Read<int>(),
                IV = reader.Read<Stats>(),
                EV = reader.Read<Stats>(),
                CurrentHP = reader.Read<short>(),
                StatusEffect = reader.Read<short>(),
                Affection = reader.Read<byte>(),
                Friendship = reader.Read<byte>(),
                Moves = reader.Read<Moves>(),
                HeldItem = reader.Read<short>(),
            };
            */
        }

        #endregion MonsterInstanceData



        private static void WriteMonsterTeam(PacketSerializer serializer, MonsterTeam value, bool writeDefaultLength = true) { }
        private static MonsterTeam ReadMonsterTeam(PacketDeserialiser deserialiser, int length = 0) { return default(MonsterTeam); }


        private static void WriteMetaSwitch(PacketSerializer serializer, MetaSwitch value, bool writeDefaultLength = true) { serializer.Write(value.Meta); }
        private static MetaSwitch ReadMetaSwitch(PacketDeserialiser deserialiser, int length = 0) => new MetaSwitch(deserialiser.Read<byte>());

        private static void WriteMetaPosition(PacketSerializer serializer, MetaPosition value, bool writeDefaultLength = true) { serializer.Write(value.Meta); }
        private static MetaPosition ReadMetaPosition(PacketDeserialiser deserialiser, int length = 0) => new MetaPosition(deserialiser.Read<long>());

        private static void WriteBattleState(PacketSerializer serializer, BattleState value, bool writeDefaultLength = true) {  }
        private static BattleState ReadBattleState(PacketDeserialiser deserialiser, int length = 0) { return default(BattleState); }

        private static void WriteMetaAttack(PacketSerializer serializer, MetaAttack value, bool writeDefaultLength = true) { serializer.Write(value.Meta); }
        private static MetaAttack ReadMetaAttack(PacketDeserialiser deserialiser, int length = 0) => new MetaAttack(deserialiser.Read<byte>());

        private static void WriteMetaItem(PacketSerializer serializer, MetaItem value, bool writeDefaultLength = true) { serializer.Write(value.Meta); }
        private static MetaItem ReadMetaItem(PacketDeserialiser deserialiser, int length = 0) => new MetaItem(deserialiser.Read<short>());


        private static void WriteBan(PacketSerializer serializer, Ban value, bool writeDefaultLength = true)
        {
            serializer.Write(value.Name);
            serializer.Write(value.IP);
            serializer.Write(value.BanTime);
            serializer.Write(value.UnBanTime);
            serializer.Write(value.Reason);
        }
        private static Ban ReadBan(PacketDeserialiser deserialiser, int length = 0)
        {
            var value = new Ban();
            value.Name = deserialiser.Read(value.Name);
            value.IP = deserialiser.Read(value.IP);
            value.BanTime = deserialiser.Read(value.BanTime);
            value.UnBanTime = deserialiser.Read(value.UnBanTime);
            value.Reason = deserialiser.Read(value.Reason);

            return value;
        }

        private static void WriteLog(PacketSerializer serializer, Log value, bool writeDefaultLength = true)
        {
            serializer.Write(value.LogFileName);
        }
        private static Log ReadLog(PacketDeserialiser deserialiser, int length = 0)
        {
            var value = new Log();
            value.LogFileName = deserialiser.Read(value.LogFileName);

            return value;
        }

        private static void WritePlayerDatabase(PacketSerializer serializer, PlayerDatabase value, bool writeDefaultLength = true)
        {
            serializer.Write(value.Name);
            serializer.Write(value.LastIP);
            serializer.Write(value.LastSeen);
        }
        private static PlayerDatabase ReadPlayerDatabase(PacketDeserialiser deserialiser, int length = 0)
        {
            var value = new PlayerDatabase();
            value.Name = deserialiser.Read(value.Name);
            value.LastIP = deserialiser.Read(value.LastIP);
            value.LastSeen = deserialiser.Read(value.LastSeen);

            return value;
        }

        private static void WritePlayerInfo(PacketSerializer serializer, PlayerInfo value, bool writeDefaultLength = true)
        {
            serializer.Write(value.Name);
            serializer.Write(value.IP);
            serializer.Write(value.Ping);
            serializer.Write(value.Position);
            serializer.Write(value.LevelFile);
            serializer.Write(value.PlayTime);
        }
        private static PlayerInfo ReadPlayerInfo(PacketDeserialiser deserialiser, int length = 0)
        {
            var value = new PlayerInfo();
            value.Name = deserialiser.Read(value.Name);
            value.IP = deserialiser.Read(value.IP);
            value.Ping = deserialiser.Read(value.Ping);
            value.Position = deserialiser.Read(value.Position);
            value.LevelFile = deserialiser.Read(value.LevelFile);
            value.PlayTime = deserialiser.Read(value.PlayTime);

            return value;
        }


        private static void WriteBanArray(PacketSerializer serializer, Ban[] value, bool writeDefaultLength = true)
        {
            serializer.Write(new VarInt(value.Length));

            foreach (var playerInfo in value)
                serializer.Write(playerInfo);
        }
        private static Ban[] ReadBanArray(PacketDeserialiser deserialiser, int length = 0)
        {
            if (length == 0)
                length = deserialiser.Read<VarInt>();

            var array = new Ban[length];

            for (var i = 0; i < length; i++)
                array[i] = ReadBan(deserialiser);

            return array;
        }

        private static void WriteLogArray(PacketSerializer serializer, Log[] value, bool writeDefaultLength = true)
        {
            serializer.Write(new VarInt(value.Length));

            foreach (var playerInfo in value)
                serializer.Write(playerInfo);
        }
        private static Log[] ReadLogArray(PacketDeserialiser deserialiser, int length = 0)
        {
            if (length == 0)
                length = deserialiser.Read<VarInt>();

            var array = new Log[length];

            for (var i = 0; i < length; i++)
                array[i] = ReadLog(deserialiser);

            return array;
        }

        private static void WritePlayerDatabaseArray(PacketSerializer serializer, PlayerDatabase[] value, bool writeDefaultLength = true)
        {
            serializer.Write(new VarInt(value.Length));

            foreach (var playerInfo in value)
                serializer.Write(playerInfo);
        }
        private static PlayerDatabase[] ReadPlayerDatabaseArray(PacketDeserialiser deserialiser, int length = 0)
        {
            if (length == 0)
                length = deserialiser.Read<VarInt>();

            var array = new PlayerDatabase[length];

            for (var i = 0; i < length; i++)
                array[i] = ReadPlayerDatabase(deserialiser);

            return array;
        }

        private static void WritePlayerInfoArray(PacketSerializer serializer, PlayerInfo[] value, bool writeDefaultLength = true)
        {
            serializer.Write(new VarInt(value.Length));

            foreach (var playerInfo in value)
                serializer.Write(playerInfo);
        }
        private static PlayerInfo[] ReadPlayerInfoArray(PacketDeserialiser deserialiser, int length = 0)
        {
            if (length == 0)
                length = deserialiser.Read<VarInt>();

            var array = new PlayerInfo[length];

            for (var i = 0; i < length; i++)
                array[i] = ReadPlayerInfo(deserialiser);

            return array;
        }
    }
}