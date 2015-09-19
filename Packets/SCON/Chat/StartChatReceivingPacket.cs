using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class StartChatReceivingPacket : ProtobufPacket
    {
        public override int ID => (int) SCONPacketTypes.PlayerListRequest;

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
