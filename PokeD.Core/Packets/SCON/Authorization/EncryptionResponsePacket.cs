using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class EncryptionResponsePacket : SCONPacket
    {
        public byte[] SharedSecret { get; set; } = new byte[0];
        public byte[] VerificationToken { get; set; } = new byte[0];


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
