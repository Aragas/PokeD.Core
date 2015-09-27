using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerInfoListRequestPacket : ProtobufPacket
    {
        public override int ID => (int) SCONPacketTypes.PlayerInfoListRequest;

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
