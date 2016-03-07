using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Battle
{
    public class BattleJoinPacket : P3DPacket
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0]); } set { DataItems[0] = value.ToString(); } }


        public override int ID => (int) P3DPacketTypes.BattleJoin;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerID = reader.Read(DestinationPlayerID);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream writer)
        {
            if (!writer.IsServer)
                writer.Write(DestinationPlayerID);

            return this;
        }
    }
}
