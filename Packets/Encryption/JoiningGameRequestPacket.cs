using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Encryption
{
    public class JoiningGameRequestPacket : P3DPacket
    {
        public override VarInt ID => (int) GamePacketTypes.JoiningGameRequest;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            return this;
        }
    }
}
