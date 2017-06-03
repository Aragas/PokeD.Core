using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.PokeD.Structs;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleSwitchPacket : PokeDPacket
    {
        private MetaSwitch Info { get; set; }
        public byte CurrentMonster { get { return Info.CurrentMonster; } set { Info = new MetaSwitch(value, SwitchMonster); } }
        public byte SwitchMonster { get { return Info.SwitchMonster; } set { Info = new MetaSwitch(CurrentMonster, value); } }


        public override VarInt ID => PokeDPacketTypes.BattleSwitch;

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
