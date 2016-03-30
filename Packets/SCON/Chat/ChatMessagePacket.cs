using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class ChatMessagePacket : SCONPacket
    {
        public string Player { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;


        public override VarInt ID => SCONPacketTypes.ChatMessage;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Player = reader.Read(Player);
            Message = reader.Read(Message);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(Player);
            stream.Write(Message);

            return this;
        }
    }
}
