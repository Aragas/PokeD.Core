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

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            PlayerID = deserialiser.Read(PlayerID);
            TrainerSprite = deserialiser.Read(TrainerSprite);
            Name = deserialiser.Read(Name);

            TrainerID = deserialiser.Read(TrainerID);
            Gender = deserialiser.Read(Gender);

            MonsterTeam = deserialiser.Read(MonsterTeam);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(PlayerID);
            serializer.Write(TrainerSprite);
            serializer.Write(Name);

            serializer.Write(TrainerID);
            serializer.Write(Gender);

            serializer.Write(MonsterTeam);
        }
    }
}
