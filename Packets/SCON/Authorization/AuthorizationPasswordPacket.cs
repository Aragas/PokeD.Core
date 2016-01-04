using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationPasswordPacket : SCONPacket
    {
        public string PasswordHash { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.AuthorizationPassword;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            PasswordHash = reader.Read(PasswordHash);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(PasswordHash);

            return this;
        }
    }
}
