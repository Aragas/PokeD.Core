using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Encryption
{
    public class EncryptionRequestPacket : P3DPacket
    {
        public byte[] PublicKey { get; set; }
        public byte[] VerificationToken { get; set; }

        public override int ID => (int) GamePacketTypes.EncryptionRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            var pkLength = reader.ReadVarInt();
            PublicKey = reader.ReadByteArray(pkLength);
            var vtLength = reader.ReadVarInt();
            VerificationToken = reader.ReadByteArray(vtLength);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteVarInt(PublicKey.Length);
            stream.WriteByteArray(PublicKey);
            stream.WriteVarInt(VerificationToken.Length);
            stream.WriteByteArray(VerificationToken);

            return this;
        }
    }
}
