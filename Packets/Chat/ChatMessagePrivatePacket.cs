using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Chat
{
    public class ChatMessagePrivatePacket : P3DPacket
    {
        public string DestinationPlayerName { get { return DataItems[0]; } set { DataItems[0] = value; } }
        public string Message { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override VarInt ID => (int) GamePacketTypes.ChatMessagePrivate;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerName = reader.ReadString();
            Message = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            if (!writer.IsServer)
                writer.Write(DestinationPlayerName);
            writer.Write(Message);

            return this;
        }
    }
}
