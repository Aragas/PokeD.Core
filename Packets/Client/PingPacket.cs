using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Client
{
    public class PingPacket : Packet
    {
        public override int ID => (int) PlayerPacketTypes.Ping;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            return this;
        }

        public override Packet WritePacket(IPacketStream writer)
        {
            return this;
        }
    }
}
