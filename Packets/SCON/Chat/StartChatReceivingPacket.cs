using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class StartChatReceivingPacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.StartChatReceiving;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            return this;
        }
    }
}
