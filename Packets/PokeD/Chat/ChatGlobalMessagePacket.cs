using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Chat
{
    public class ChatGlobalMessagePacket : PokeDPacket
    {
        public string Message { get; set; } = string.Empty;


        public override VarInt ID => PokeDPacketTypes.ChatGlobalMessage;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Message = reader.Read(Message);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(Message);

            return this;
        }
    }
}
