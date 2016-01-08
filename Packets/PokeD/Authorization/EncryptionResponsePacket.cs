using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class EncryptionResponsePacket : PokeDPacket
    {
        public byte[] SharedSecret;
        public byte[] VerificationToken;


        public override VarInt ID => (int) PokeDPacketTypes.EncryptionResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            SharedSecret = reader.Read(SharedSecret);
            VerificationToken = reader.Read(VerificationToken);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(SharedSecret);
            stream.Write(VerificationToken);

            return this;
        }
    }
}
