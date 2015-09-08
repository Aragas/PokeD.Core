using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Chat
{
    public class ChatMessagePrivatePacket : Packet
    {
        public string DestinationPlayerName { get { return DataItems[0]; } set { DataItems[0] = value; } }
        public string Message { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override int ID => (int) PlayerPacketTypes.PrivateMessage;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerName = reader.ReadString();
            Message = reader.ReadString();

            return this;
        }

        public override Packet WritePacket(IPacketStream writer)
        {
            if (!writer.IsServer)
                writer.WriteString(DestinationPlayerName);
            writer.WriteString(Message);

            return this;
        }
    }
}
