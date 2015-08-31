using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Remote.Authorization
{
    public class EncryptionResponsePacket : IPacket
    {
        public byte[] SharedSecret { get; set; }
        public byte[] VerificationToken { get; set; }

        public override int ID { get { return (int) RemotePacketTypes.EncryptionResponsePacket; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            var ssLength = reader.ReadVarInt();
            SharedSecret = reader.ReadByteArray(ssLength);
            var vtLength = reader.ReadVarInt();
            VerificationToken = reader.ReadByteArray(vtLength);

            return this;
        }

        public override IPacket WritePacket(IPokeStream stream)
        {
            stream.WriteVarInt(SharedSecret.Length);
            stream.WriteByteArray(SharedSecret);
            stream.WriteVarInt(VerificationToken.Length);
            stream.WriteByteArray(VerificationToken);

            return this;
        }
    }
}
