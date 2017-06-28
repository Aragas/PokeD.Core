using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationCompletePacket : SCONPacket
    {
        public override void Deserialize(ProtobufDeserialiser deserialiser) { }
        public override void Serialize(ProtobufSerializer serializer) { }
    }
}
