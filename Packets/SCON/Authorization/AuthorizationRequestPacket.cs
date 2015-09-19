using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationRequestPacket : ProtobufPacket
    {
        public override int ID => (int) SCONPacketTypes.AuthorizationRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            return this;
        }
    }
}
