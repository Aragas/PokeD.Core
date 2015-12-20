using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Client
{
    public class PingPacket : P3DPacket
    {
        public override VarInt ID => (int) GamePacketTypes.Ping;

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
