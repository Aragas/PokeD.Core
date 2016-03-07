using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Encryption
{
    public class JoiningGameResponsePacket : P3DPacket
    {
        public bool EncryptionEnabled;

        public override int ID => (int) P3DPacketTypes.JoiningGameResponse;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            EncryptionEnabled = reader.Read(EncryptionEnabled);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream stream)
        {
            stream.Write(EncryptionEnabled);

            return this;
        }
    }
}
