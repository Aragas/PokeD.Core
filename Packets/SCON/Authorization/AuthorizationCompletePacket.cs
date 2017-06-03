using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationCompletePacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.AuthorizationComplete;

        public override void Deserialize(ProtobufDeserialiser deserialiser) { }
        public override void Serialize(ProtobufSerializer serializer) { }
    }
}
