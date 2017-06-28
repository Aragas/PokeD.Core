using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.PokeD.Structs;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleAttackPacket : PokeDPacket
    {
        private MetaAttack Info { get; set; }

        public byte CurrentMonster { get { return Info.CurrentMonster; } set { Info = new MetaAttack(value, Move, TargetMonster); } }
        public byte Move { get { return Info.Move; } set { Info = new MetaAttack(CurrentMonster, value, TargetMonster); } }
        public byte TargetMonster { get { return Info.TargetMonster; } set { Info = new MetaAttack(CurrentMonster, Move, value); } }


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            Info = deserialiser.Read(Info);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(Info);
        }
    }
}
