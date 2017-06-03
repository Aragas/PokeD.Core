using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerDatabaseListRequestPacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.PlayerDatabaseListRequest;

        public override void Deserialize(ProtobufDeserialiser deserialiser) { }
        public override void Serialize(ProtobufSerializer serializer) { }
    }
}
