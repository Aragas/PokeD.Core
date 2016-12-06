using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Chat
{
    public class ChatPrivateMessagePacket : PokeDPacket
    {
        public VarInt PlayerId { get; set; }
        public string Message { get; set; } = string.Empty;


        public override VarInt ID => PokeDPacketTypes.ChatPrivateMessage;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PlayerId = reader.Read(PlayerId);
            Message = reader.Read(Message);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(PlayerId);
            writer.Write(Message);

            return this;
        }
    }
}
