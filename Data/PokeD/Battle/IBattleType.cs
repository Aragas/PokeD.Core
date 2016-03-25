using Aragas.Core.Data;
using Aragas.Core.IO;

namespace PokeD.Core.Data.PokeD.Battle
{
    public enum BattleType
    {
        PvP_1 = 1,  // 1  vs 1                          // One vs One
        PvP_2 = 2,  // 1D vs 1D                         // One Double vs One Double
        PvP_3 = 3,  // 2  vs 2                          // Two vs Two
        PvP_4 = 4,  // 3  vs 3                          // Three vs Three
        PvP_5 = 5,  // 1  vs 1  vs 1  vs 1              // One vs One vs One vs One, Deathmatch

        PvE_1 = 10, // 1  vs E                          // One vs NPC
        PvE_2 = 11, // 1D vs ED                         // One Double vs NPC Double
        PvE_3 = 12, // 2  vs 2E                         // Two vs Two NPC
        PvE_4 = 13, // 3  vs 3E                         // Three vs Three NPC
        PvE_5 = 14, // 1  vs 1  vs 1  vs E              // One vs One vs One vs NPC, Deathmatch
        PvE_6 = 15, // 1  vs 1  vs E  vs E              // One vs One vs NPC vs NPC, Deathmatch
        PvE_7 = 16, // 1  vs E  vs E  vs E              // One vs NPC vs NPC vs NPC, Deathmatch
        PvE_8 = 17, // 1  vs E  vs E  vs E  vs E  vs E  // One vs NPC vs NPC vs NPC, Deathmatch

        T_1 = 20, //                                    // Tournament
    }
    /*
    public interface IBattleType
    {
        IBattleType FromReader(ProtobufDataReader reader);
        IBattleType ToStream(ProtobufStream stream);
    }
    public class Battle2 : IBattleType
    {
        public VarInt Client_1 { get; set; }
        public VarInt Client_2 { get; set; }

        public IBattleType FromReader(ProtobufDataReader reader)
        {
            Client_1 = reader.Read(Client_1);
            Client_2 = reader.Read(Client_2);

            return this;
        }
        public IBattleType ToStream(ProtobufStream writer)
        {
            writer.Write(Client_1);
            writer.Write(Player_2);

            return this;
        }
    }
    public class Battle4 : IBattleType
    {
        public VarInt Client_1 { get; set; }
        public VarInt Client_2 { get; set; }
        public VarInt Client_3 { get; set; }
        public VarInt Client_4 { get; set; }

        public IBattleType FromReader(ProtobufDataReader reader)
        {
            Client_1 = reader.Read(Client_1);
            Client_2 = reader.Read(Client_2);
            Client_3 = reader.Read(Client_3);
            Client_4 = reader.Read(Client_4);

            return this;
        }
        public IBattleType ToStream(ProtobufStream writer)
        {
            writer.Write(Client_1);
            writer.Write(Client_2);
            writer.Write(Client_3);
            writer.Write(Client_4);

            return this;
        }
    }
    public class Battle6 : IBattleType
    {
        public VarInt Client_1 { get; set; }
        public VarInt Client_2 { get; set; }
        public VarInt Client_3 { get; set; }
        public VarInt Client_4 { get; set; }
        public VarInt Client_5 { get; set; }
        public VarInt Client_6 { get; set; }

        public IBattleType FromReader(ProtobufDataReader reader)
        {
            Client_1 = reader.Read(Client_1);
            Client_2 = reader.Read(Client_2);
            Client_3 = reader.Read(Client_3);
            Client_4 = reader.Read(Client_4);
            Client_5 = reader.Read(Client_5);
            Client_6 = reader.Read(Client_6);

            return this;
        }
        public IBattleType ToStream(ProtobufStream writer)
        {
            writer.Write(Client_1);
            writer.Write(Client_2);
            writer.Write(Client_3);
            writer.Write(Client_4);
            writer.Write(Client_5);
            writer.Write(Client_6);

            return this;
        }
    }
    */
}
