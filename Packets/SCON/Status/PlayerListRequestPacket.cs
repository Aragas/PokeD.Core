using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerListRequestPacket : Packet
    {
        public override int ID => (int) SCONPacketTypes.PlayerListRequest;

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
