using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Encryption
{
    public class JoiningGameResponsePacket : P3DPacket
    {
        public bool EncryptionEnabled;

        public override VarInt ID => (int) GamePacketTypes.JoiningGameResponse;

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
