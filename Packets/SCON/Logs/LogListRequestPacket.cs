using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogListRequestPacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.LogListRequest;

        public override void Deserialize(ProtobufDeserialiser deserialiser) { }
        public override void Serialize(ProtobufSerializer serializer) { }
    }
}
