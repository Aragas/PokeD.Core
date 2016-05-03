using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationPasswordPacket : SCONPacket
    {
        public string PasswordHash { get; set; } = string.Empty;


        public override VarInt ID => SCONPacketTypes.AuthorizationPassword;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PasswordHash = reader.Read(PasswordHash);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(PasswordHash);

            return this;
        }
    }
}
