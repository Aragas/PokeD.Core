using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class EncryptionRequestPacket : ProtobufPacket
    {
        public string ServerId { get; set; }
        public byte[] PublicKey { get; set; }
        public byte[] VerificationToken { get; set; }

        public override int ID => (int) SCONPacketTypes.EncryptionRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            ServerId = reader.ReadString();
            var pkLength = reader.ReadVarInt();
            PublicKey = reader.ReadByteArray(pkLength);
            var vtLength = reader.ReadVarInt();
            VerificationToken = reader.ReadByteArray(vtLength);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(ServerId);
            stream.WriteVarInt(PublicKey.Length);
            stream.WriteByteArray(PublicKey);
            stream.WriteVarInt(VerificationToken.Length);
            stream.WriteByteArray(VerificationToken);

            return this;
        }
    }
}
