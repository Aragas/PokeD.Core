using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class StartChatReceivingPacket : ProtobufPacket
    {
        public override int ID => (int) SCONPacketTypes.StartChatReceiving;

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
