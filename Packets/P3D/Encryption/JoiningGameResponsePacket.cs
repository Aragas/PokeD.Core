using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.P3D.Encryption
{
    public class JoiningGameResponsePacket : P3DPacket
    {
        public bool EncryptionEnabled;

        public override VarInt ID => (int) P3DPacketTypes.JoiningGameResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            EncryptionEnabled = reader.Read(EncryptionEnabled);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(EncryptionEnabled);

            return this;
        }
    }
}
