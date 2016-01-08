using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Chat
{
    public class ChatServerMessagePacket : PokeDPacket
    {
        public string Message { get; set; }


        public override VarInt ID => (int) PokeDPacketTypes.ChatServerMessage;

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
