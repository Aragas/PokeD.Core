using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationCompletePacket : Packet
    {
        public override int ID => (int) SCONPacketTypes.AuthorizationComplete;

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
