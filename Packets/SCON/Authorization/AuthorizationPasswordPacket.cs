using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationPasswordPacket : SCONPacket
    {
        public string PasswordHash { get; set; }

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
