using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class EncryptionResponsePacket : PokeDPacket
    {
        public byte[] SharedSecret { get; set; } = new byte[0];
        public byte[] VerificationToken { get; set; } = new byte[0];


        public override VarInt ID => PokeDPacketTypes.EncryptionResponse;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            SharedSecret = deserialiser.Read(SharedSecret);
            VerificationToken = deserialiser.Read(VerificationToken);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(SharedSecret);
            serializer.Write(VerificationToken);
        }
    }
}
