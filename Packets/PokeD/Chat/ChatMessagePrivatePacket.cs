using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Chat
{
    public class ChatMessagePrivatePacket : P3DPacket
    {
        public VarInt PlayerID { get; set; }
        public string Message { get; set; }


        public override VarInt ID => (int) P3DPacketTypes.ChatMessagePrivate;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            PlayerID = reader.Read(PlayerID);
            Message = reader.Read(Message);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(PlayerID);
            writer.Write(Message);

            return this;
        }
    }
}
