using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class AuthorizationDisconnectPacket : PokeDPacket
    {
        public string Reason { get; set; } = string.Empty;


        public override VarInt ID => PokeDPacketTypes.AuthorizationDisconnect;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            Reason = deserialiser.Read(Reason);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(Reason);
        }
    }
}
