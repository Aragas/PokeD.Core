using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.P3D.Encryption
{
    public class JoiningGameRequestPacket : P3DPacket
    {
        public override VarInt ID => (int) P3DPacketTypes.JoiningGameRequest;

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
