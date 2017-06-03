using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogListRequestPacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.CrashLogListRequest;

        public override void Deserialize(ProtobufDeserialiser deserialiser) { }
        public override void Serialize(ProtobufSerializer serializer) { }
    }
}
