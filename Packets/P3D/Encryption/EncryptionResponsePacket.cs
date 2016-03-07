using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Encryption
{
    public class EncryptionResponsePacket : P3DPacket
    {
        public byte[] SharedSecret;
        public byte[] VerificationToken;

        public override int ID => (int) P3DPacketTypes.EncryptionResponse;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            SharedSecret = reader.Read(SharedSecret);
            VerificationToken = reader.Read(VerificationToken);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream stream)
        {
            stream.Write(SharedSecret);
            stream.Write(VerificationToken);

            return this;
        }
    }
}
