using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Encryption
{
    public class EncryptionRequestPacket : P3DPacket
    {
        public byte[] PublicKey { get; set; }
        public byte[] VerificationToken { get; set; }

        public override VarInt ID => (int) GamePacketTypes.EncryptionRequest;

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
            stream.Write(new VarInt(PublicKey.Length));
            stream.Write(PublicKey);
            stream.Write(new VarInt(VerificationToken.Length));
            stream.Write(VerificationToken);

            return this;
        }
    }
}
