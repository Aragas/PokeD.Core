using Aragas.Core.Data;
using Aragas.Core.IO;
using PokeD.Core.Data.PokeD.Trainer.Interfaces;

namespace PokeD.Core.Data.PokeD.Battle
{
    public interface IBattleInfo
    {
        int Count { get; }

        IBattleInfo FromReader(ProtobufDataReader reader);
        IBattleInfo ToStream(ProtobufStream stream);
    }

    public class BattleInfo1x5 : IBattleInfo
    {
        public VarInt Opponent_0 { get; set; }
        public VarInt Opponent_1 { get; set; }
        public VarInt Opponent_2 { get; set; }
        public VarInt Opponent_3 { get; set; }
        public VarInt Opponent_4 { get; set; }
        public VarInt Opponent_5 { get; set; }

        public int Count => 6;

        public IBattleInfo FromReader(ProtobufDataReader reader)
        {
            Opponent_0 = reader.Read(Opponent_0);
            Opponent_1 = reader.Read(Opponent_1);
            Opponent_2 = reader.Read(Opponent_1);
            Opponent_3 = reader.Read(Opponent_1);
            Opponent_4 = reader.Read(Opponent_1);
            Opponent_5 = reader.Read(Opponent_1);

            return this;
        }
        public IBattleInfo ToStream(ProtobufStream writer)
        {
            writer.Write(Opponent_0);
            writer.Write(Opponent_1);
            writer.Write(Opponent_2);
            writer.Write(Opponent_3);
            writer.Write(Opponent_4);
            writer.Write(Opponent_5);

            return this;
        }
    }
    public class BattleInfo3x3 : IBattleInfo
    {
        public VarInt Opponent_0 { get; set; }
        public VarInt Opponent_1 { get; set; }
        public VarInt Opponent_2 { get; set; }
        public VarInt Opponent_3 { get; set; }
        public VarInt Opponent_4 { get; set; }
        public VarInt Opponent_5 { get; set; }

        public int Count => 6;

        public IBattleInfo FromReader(ProtobufDataReader reader)
        {
            Opponent_0 = reader.Read(Opponent_0);
            Opponent_1 = reader.Read(Opponent_1);
            Opponent_2 = reader.Read(Opponent_1);
            Opponent_3 = reader.Read(Opponent_1);
            Opponent_4 = reader.Read(Opponent_1);
            Opponent_5 = reader.Read(Opponent_1);

            return this;
        }
        public IBattleInfo ToStream(ProtobufStream writer)
        {
            writer.Write(Opponent_0);
            writer.Write(Opponent_1);
            writer.Write(Opponent_2);
            writer.Write(Opponent_3);
            writer.Write(Opponent_4);
            writer.Write(Opponent_5);

            return this;
        }
    }
    public class BattleInfo2x2 : IBattleInfo
    {
        public VarInt Opponent_0 { get; set; }
        public VarInt Opponent_1 { get; set; }
        public VarInt Opponent_2 { get; set; }
        public VarInt Opponent_3 { get; set; }

        public int Count => 4;

        public IBattleInfo FromReader(ProtobufDataReader reader)
        {
            Opponent_0 = reader.Read(Opponent_0);
            Opponent_1 = reader.Read(Opponent_1);
            Opponent_2 = reader.Read(Opponent_1);
            Opponent_3 = reader.Read(Opponent_1);

            return this;
        }
        public IBattleInfo ToStream(ProtobufStream writer)
        {
            writer.Write(Opponent_0);
            writer.Write(Opponent_1);
            writer.Write(Opponent_2);
            writer.Write(Opponent_3);

            return this;
        }
    }
    public class BattleInfo1x1 : IBattleInfo
    {
        public VarInt Opponent_0 { get; set; }
        public VarInt Opponent_1 { get; set; }

        public int Count => 2;

        public IBattleInfo FromReader(ProtobufDataReader reader)
        {
            Opponent_0 = reader.Read(Opponent_0);
            Opponent_1 = reader.Read(Opponent_1);

            return this;
        }
        public IBattleInfo ToStream(ProtobufStream writer)
        {
            writer.Write(Opponent_0);
            writer.Write(Opponent_1);

            return this;
        }
    }
}