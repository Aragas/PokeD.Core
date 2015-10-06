using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Encryption
{
    public class JoiningGameResponsePacket : P3DPacket
    {
        public bool EncryptionEnabled;

        public override VarInt ID => (int) GamePacketTypes.JoiningGameResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            EncryptionEnabled = reader.Read(EncryptionEnabled);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(EncryptionEnabled);

            return this;
        }
    }
}
