using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class ChatMessagePacket : ProtobufPacket
    {
        public string Player;
        public string Message;

        public override VarInt ID => (int) SCONPacketTypes.ChatMessage;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Player = reader.Read(Player);
            Message = reader.Read(Message);

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
