using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.P3D.Client
{
    public class PingPacket : P3DPacket
    {
        public override VarInt ID => (int) P3DPacketTypes.Ping;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            return this;
        }
    }
}
