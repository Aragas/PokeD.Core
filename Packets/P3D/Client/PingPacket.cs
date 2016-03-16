using PokeD.Core.IO;

namespace PokeD.Core.Packets.P3D.Client
{
    public class PingPacket : P3DPacket
    {
        public override int ID => (int) P3DPacketTypes.Ping;

        public override P3DPacket ReadPacket(P3DDataReader reader) { return this; }
        public override P3DPacket WritePacket(P3DStream writer) { return this; }
    }
}
