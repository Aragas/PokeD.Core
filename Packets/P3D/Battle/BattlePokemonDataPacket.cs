using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Battle
{
    public class BattlePokemonDataPacket : P3DPacket
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0]); } set { DataItems[0] = value.ToString(); } }
        public string BattleData { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override int ID => (int) P3DPacketTypes.BattlePokemonData;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerID = reader.Read(DestinationPlayerID);

            BattleData = reader.Read(BattleData);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream writer)
        {
            if (!writer.IsServer)
                writer.Write(DestinationPlayerID);
            writer.Write(BattleData);

            return this;
        }
    }
}
