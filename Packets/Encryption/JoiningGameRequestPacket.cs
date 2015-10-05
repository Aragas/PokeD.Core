using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Encryption
{
    public class JoiningGameRequestPacket : P3DPacket
    {
        public override VarInt ID => (int) GamePacketTypes.JoiningGameRequest;

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
