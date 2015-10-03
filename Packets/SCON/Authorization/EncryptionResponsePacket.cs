using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class EncryptionResponsePacket : ProtobufPacket
    {
        public byte[] SharedSecret { get; set; }
        public byte[] VerificationToken { get; set; }

        public override int ID => (int) SCONPacketTypes.EncryptionResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            var ssLength = reader.ReadVarInt();
            SharedSecret = reader.ReadByteArray(ssLength);
            var vtLength = reader.ReadVarInt();
            VerificationToken = reader.ReadByteArray(vtLength);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteVarInt(SharedSecret.Length);
            stream.WriteByteArray(SharedSecret);
            stream.WriteVarInt(VerificationToken.Length);
            stream.WriteByteArray(VerificationToken);

            return this;
        }
    }
}
