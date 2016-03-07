using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Chat
{
    public class ChatMessagePrivatePacket : P3DPacket
    {
        public string DestinationPlayerName { get { return DataItems[0]; } set { DataItems[0] = value; } }
        public string Message { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override int ID => (int) P3DPacketTypes.ChatMessagePrivate;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerName = reader.Read(DestinationPlayerName);
            
            Message = reader.Read(Message);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream writer)
        {
            if (!writer.IsServer)
                writer.Write(DestinationPlayerName);
            writer.Write(Message);

            return this;
        }
    }
}
