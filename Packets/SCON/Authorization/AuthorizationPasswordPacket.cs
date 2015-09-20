using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationPasswordPacket : ProtobufPacket
    {
        public string Password { get; set; }

        public override int ID => (int) SCONPacketTypes.AuthorizationPassword;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Password = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(Password);

            return this;
        }
    }
}
