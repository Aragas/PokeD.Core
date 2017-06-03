using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Status
{
    public class BanListRequestPacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.BanListRequest;

        public override void Deserialize(ProtobufDeserialiser deserialiser) { }
        public override void Serialize(ProtobufSerializer serializer) { }
    }
}
