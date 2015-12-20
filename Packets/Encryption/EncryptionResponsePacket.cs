using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Encryption
{
    public class EncryptionResponsePacket : P3DPacket
    {
        public byte[] SharedSecret;
        public byte[] VerificationToken;

        public override VarInt ID => (int) GamePacketTypes.EncryptionResponse;

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
