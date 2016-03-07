using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Encryption
{
    public class EncryptionRequestPacket : P3DPacket
    {
        public byte[] PublicKey;
        public byte[] VerificationToken;

        public override int ID => (int) P3DPacketTypes.EncryptionRequest;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            PublicKey = reader.Read(PublicKey);
            VerificationToken = reader.Read(VerificationToken);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream stream)
        {
            stream.Write(PublicKey);
            stream.Write(VerificationToken);

            return this;
        }
    }
}
