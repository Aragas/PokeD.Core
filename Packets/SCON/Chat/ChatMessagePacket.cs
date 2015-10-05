using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class ChatMessagePacket : ProtobufPacket
    {
        public string Player { get; set; }
        public string Message { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.ChatMessage;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Player = reader.ReadString();
            Message = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(Player);
            stream.Write(Message);

            return this;
        }
    }
}
