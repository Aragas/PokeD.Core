using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationRequestPacket : Packet
    {
        public override int ID => (int) SCONPacketTypes.AuthorizationRequest;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            return this;
        }

        public override Packet WritePacket(IPacketStream stream)
        {
            return this;
        }
    }
}
