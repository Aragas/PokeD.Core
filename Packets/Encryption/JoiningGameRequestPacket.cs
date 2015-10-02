using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Encryption
{
    public class JoiningGameRequestPacket : P3DPacket
    {
        public override int ID => (int) GamePacketTypes.JoiningGameRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            return this;
        }
    }
}
