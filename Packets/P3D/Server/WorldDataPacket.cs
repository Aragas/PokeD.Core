using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Server
{
    public class WorldDataPacket : P3DPacket
    {
        public int Season { get { return int.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0]); } set { DataItems[0] = value.ToString(); } }
        public int Weather { get { return int.Parse(DataItems[1] == string.Empty ? 0.ToString() : DataItems[1]); } set { DataItems[1] = value.ToString(); } }
        public string CurrentTime { get { return DataItems[2]; } set { DataItems[2] = value; } }


        public override int ID => (int) P3DPacketTypes.WorldData;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            Season = reader.Read(Season);
            Weather = reader.Read(Weather);
            CurrentTime = reader.Read(CurrentTime);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream writer)
        {
            writer.Write(Season);
            writer.Write(Weather);
            writer.Write(CurrentTime);

            return this;
        }
    }
}
