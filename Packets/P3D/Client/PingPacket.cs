using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Client
{
    public class PingPacket : P3DPacket
    {
        public override int ID => (int) P3DPacketTypes.Ping;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            return this;
        }

        public override P3DPacket WritePacket(PacketStream writer)
        {
            return this;
        }
    }
}
