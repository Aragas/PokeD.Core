using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Client
{
    public class PingPacket : P3DPacket
    {
        public override int ID => (int) GamePacketTypes.Ping;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            return this;
        }
    }
}
