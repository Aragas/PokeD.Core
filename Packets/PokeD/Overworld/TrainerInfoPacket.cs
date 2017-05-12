using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.BattleEngine.Trainer.Data;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.PokeD.Overworld
{
    public class MetaTrainerInfo
    {
        public byte Meta { get; private set; }



        /// <summary>
        /// Index of used Monster.
        /// </summary>
        /// <remarks>Range 0-3, used 0-1.</remarks>
        public byte CurrentMonster { get { return Meta.BitsGet(0, 2); } set { Meta = Meta.BitsSet(value, 0, 2); } }

        /// <summary>
        /// Index of used Move.
        /// </summary>
        /// <remarks>Range 0-3, used 0-3.</remarks>
        public byte Move { get { return Meta.BitsGet(2, 4); } set { Meta = Meta.BitsSet(value, 2, 4); } }

        /// <summary>
        /// Index of used Monster. 16 is All. 15 is All except Attacker
        /// </summary>
        /// <remarks>Range 0-15, used 0-15.</remarks>
        public byte TargetMonster { get { return Meta.BitsGet(4, 8); } set { Meta = Meta.BitsSet(value, 4, 8); } }


        public MetaTrainerInfo(byte currentMonster, byte move, byte targetMonster) { CurrentMonster = currentMonster; Move = move; TargetMonster = targetMonster; }
        public MetaTrainerInfo(byte meta) { Meta = meta; }
    }

    public class TrainerInfoPacket : PokeDPacket
    {
        public VarInt PlayerID { get; set; }
        public short TrainerSprite { get; set; }
        public string Name { get; set; } = string.Empty;

        public short TrainerID { get; set; }
        public byte Gender { get; set; }

        public MonsterTeam MonsterTeam { get; set; } = new MonsterTeam();


        public override VarInt ID => PokeDPacketTypes.TrainerInfo;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PlayerID = reader.Read(PlayerID);
            TrainerSprite = reader.Read(TrainerSprite);
            Name = reader.Read(Name);

            TrainerID = reader.Read(TrainerID);
            Gender = reader.Read(Gender);

            MonsterTeam = reader.Read(MonsterTeam);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(PlayerID);
            writer.Write(TrainerSprite);
            writer.Write(Name);

            writer.Write(TrainerID);
            writer.Write(Gender);

            writer.Write(MonsterTeam);

            return this;
        }
    }
}
