using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Chat
{
    public class ChatMessagePacket : Packet
    {
        public string Message { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) PlayerPacketTypes.ChatMessage;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            Message = reader.ReadString();

            return this;
        }

        public override Packet WritePacket(IPacketStream writer)
        {
            writer.WriteString(Message);

            return this;
        }
    }
}
