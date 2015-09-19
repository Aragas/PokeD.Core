using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class StopChatReceivingPacket : ProtobufPacket
    {
        public override int ID => (int) SCONPacketTypes.StopChatReceiving;

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
