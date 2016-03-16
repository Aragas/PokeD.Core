using PokeD.Core.IO;

namespace PokeD.Core.Packets.P3D.Battle
{
    public class BattleHostDataPacket : P3DPacket
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0]); } set { DataItems[0] = value.ToString(); } }
        public string BattleData { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override int ID => (int) P3DPacketTypes.BattleHostData;

        public override P3DPacket ReadPacket(P3DDataReader reader) { return this; }
        public override P3DPacket WritePacket(P3DStream writer) { return this; }
    }
}
