using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Chat
{
    public class ChatServerMessagePacket : PokeDPacket
    {
        public string Message { get; set; } = string.Empty;


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            Message = deserialiser.Read(Message);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(Message);
        }
    }
}
