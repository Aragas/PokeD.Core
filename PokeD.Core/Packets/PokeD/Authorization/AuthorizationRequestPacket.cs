using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class AuthorizationRequestPacket : PokeDPacket
    {
        public string Name { get; set; } = string.Empty;


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            Name = deserialiser.Read(Name);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(Name);
        }
    }
}
