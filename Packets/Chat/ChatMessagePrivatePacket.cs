using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Chat
{
    public class ChatMessagePrivatePacket : IPacket
    {
        public string DestinationPlayerName { get { return DataItems[0]; } set { DataItems[0] = value; } }
        public string Message { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override int ID { get { return (int) PacketTypes.PrivateMessage; } }
        
        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            DestinationPlayerName = reader.ReadString();
            Message = reader.ReadString();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteString(DestinationPlayerName);
            writer.WriteString(Message);

            return this;
        }
    }
}
