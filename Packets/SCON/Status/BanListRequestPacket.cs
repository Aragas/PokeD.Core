using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class BanListRequestPacket : ProtobufPacket
    {
        public override int ID => (int) SCONPacketTypes.BanListRequest;

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
