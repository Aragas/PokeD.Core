using PokeD.Core.IO;

namespace PokeD.Core.Packets.P3D.Trade
{
    public class TradeQuitPacket : P3DPacket
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0]); } set { DataItems[0] = value.ToString(); } }


        public override int ID => (int) P3DPacketTypes.TradeQuit;

        public override P3DPacket ReadPacket(P3DDataReader reader) { return this; }
        public override P3DPacket WritePacket(P3DStream writer) { return this; }
    }
}
