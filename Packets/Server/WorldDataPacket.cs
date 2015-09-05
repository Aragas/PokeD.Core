using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Server
{
    public class WorldDataPacket : IPacket
    {
        public int Season { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public int Weather { get { return int.Parse(DataItems[1], CultureInfo); } set { DataItems[1] = value.ToString(CultureInfo); } }
        public string CurrentTime { get { return DataItems[2]; } set { DataItems[2] = value; } }


        public override int ID => (int) PlayerPacketTypes.WorldData;

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            Season = reader.ReadVarInt();
            Weather = reader.ReadVarInt();
            CurrentTime = reader.ReadString();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteVarInt(Season);
            writer.WriteVarInt(Weather);
            writer.WriteString(CurrentTime);

            return this;
        }
    }
}
