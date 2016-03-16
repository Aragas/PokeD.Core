using PokeD.Core.IO;

namespace PokeD.Core.Packets.P3D.Server
{
    public class ServerClosePacket : P3DPacket
    {
        public string Reason { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) P3DPacketTypes.ServerClose;

        public override P3DPacket ReadPacket(P3DDataReader reader) { return this; }
        public override P3DPacket WritePacket(P3DStream writer) { return this; }
    }
}
