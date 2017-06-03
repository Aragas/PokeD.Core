using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleFleePacket : PokeDPacket
    {
        public override VarInt ID => PokeDPacketTypes.BattleFlee;

        public override void Deserialize(ProtobufDeserialiser deserialiser) { }
        public override void Serialize(ProtobufSerializer serializer) { }
    }
}
