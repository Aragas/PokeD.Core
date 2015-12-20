using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Chat
{
    public class ChatMessageGlobalPacket : P3DPacket
    {
        public string Message { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override VarInt ID => (int) GamePacketTypes.ChatMessageGlobal;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Message = reader.Read(Message);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(Message);

            return this;
        }
    }
}
