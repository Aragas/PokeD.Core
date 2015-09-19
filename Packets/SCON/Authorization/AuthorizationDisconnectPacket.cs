using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationDisconnectPacket : ProtobufPacket
    {
        public string Reason { get; set; }

        public override int ID => (int) SCONPacketTypes.AuthorizationDisconnect;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Reason = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(Reason);

            return this;
        }
    }
}
