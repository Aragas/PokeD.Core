using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationPasswordPacket : ProtobufPacket
    {
        public string PasswordHash;

        public override VarInt ID => (int) SCONPacketTypes.AuthorizationPassword;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            PasswordHash = reader.Read(PasswordHash);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(PasswordHash);

            return this;
        }
    }
}
