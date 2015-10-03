using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

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
