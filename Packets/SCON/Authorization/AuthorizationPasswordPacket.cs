using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationPasswordPacket : SCONPacket
    {
        public string PasswordHash { get; set; } = string.Empty;


        public override VarInt ID => SCONPacketTypes.AuthorizationPassword;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            PasswordHash = deserialiser.Read(PasswordHash);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(PasswordHash);
        }
    }
}
