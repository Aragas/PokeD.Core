using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class StartChatReceivingPacket : ProtobufPacket
    {
        public override VarInt ID => (int) SCONPacketTypes.StartChatReceiving;

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
