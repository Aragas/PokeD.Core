using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class ChatMessagePacket : ProtobufPacket
    {
        public string Player { get; set; }
        public string Message { get; set; }

        public override int ID => (int) SCONPacketTypes.ChatMessage;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Player = reader.ReadString();
            Message = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(Player);
            stream.WriteString(Message);

            return this;
        }
    }
}
