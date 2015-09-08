using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Remote.Authorization
{
    public class AuthorizationRequestPacket : Packet
    {
        public override int ID => (int) RemotePacketTypes.AuthorizationRequestPacket;

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
