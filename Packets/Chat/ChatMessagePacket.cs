using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Chat
{
    public class ChatMessagePacket : IPacket
    {
        public string Message { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) PlayerPacketTypes.ChatMessage;

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            Message = reader.ReadString();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteString(Message);

            return this;
        }
    }
}
