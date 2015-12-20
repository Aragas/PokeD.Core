using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class EncryptionRequestPacket : ProtobufPacket
    {
        public byte[] PublicKey;
        public byte[] VerificationToken;

        public override VarInt ID => (int) SCONPacketTypes.EncryptionRequest;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            PublicKey = reader.Read(PublicKey);
            VerificationToken = reader.Read(VerificationToken);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(PublicKey);
            stream.Write(VerificationToken);

            return this;
        }
    }
}
