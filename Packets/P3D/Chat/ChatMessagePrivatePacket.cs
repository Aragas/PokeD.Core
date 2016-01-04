using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.P3D.Chat
{
    public class ChatMessagePrivatePacket : P3DPacket
    {
        public string DestinationPlayerName { get { return DataItems[0]; } set { DataItems[0] = value; } }
        public string Message { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override VarInt ID => (int) P3DPacketTypes.ChatMessagePrivate;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerName = reader.Read(DestinationPlayerName);
            
            Message = reader.Read(Message);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            if (!writer.IsServer)
                writer.Write(DestinationPlayerName);
            writer.Write(Message);

            return this;
        }
    }
}
