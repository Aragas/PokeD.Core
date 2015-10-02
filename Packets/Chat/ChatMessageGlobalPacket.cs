using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Chat
{
    public class ChatMessageGlobalPacket : P3DPacket
    {
        public string Message { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) GamePacketTypes.ChatMessageGlobal;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Message = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            writer.WriteString(Message);

            return this;
        }
    }
}
