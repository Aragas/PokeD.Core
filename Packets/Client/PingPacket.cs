using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Client
{
    public class PingP3DPacket : P3DPacket
    {
        public override int ID => (int) PlayerPacketTypes.Ping;

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
