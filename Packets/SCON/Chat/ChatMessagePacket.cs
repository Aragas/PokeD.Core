using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class ChatMessagePacket : SCONPacket
    {
        public string Player { get; set; }
        public string Message { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.ChatMessage;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Player = reader.Read(Player);
            Message = reader.Read(Message);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(Player);
            stream.Write(Message);

            return this;
        }
    }
}
