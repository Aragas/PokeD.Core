using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class EncryptionRequestPacket : PokeDPacket
    {
        public byte[] PublicKey { get; set; } = new byte[0];
        public byte[] VerificationToken { get; set; } = new byte[0];


        public override VarInt ID => PokeDPacketTypes.EncryptionRequest;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PublicKey = reader.Read(PublicKey);
            VerificationToken = reader.Read(VerificationToken);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(PublicKey);
            stream.Write(VerificationToken);

            return this;
        }
    }
}
