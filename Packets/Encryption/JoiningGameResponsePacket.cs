using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Encryption
{
    public class JoiningGameResponsePacket : P3DPacket
    {
        public bool EncryptionEnabled { get; set; }

        public override int ID => (int) GamePacketTypes.JoiningGameResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            EncryptionEnabled = reader.ReadBoolean();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteBoolean(EncryptionEnabled);

            return this;
        }
    }
}
