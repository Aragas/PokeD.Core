using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Server
{
    public class WorldDataPacket : P3DPacket
    {
        public int Season { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public int Weather { get { return int.Parse(DataItems[1], CultureInfo); } set { DataItems[1] = value.ToString(CultureInfo); } }
        public string CurrentTime { get { return DataItems[2]; } set { DataItems[2] = value; } }


        public override int ID => (int) GamePacketTypes.WorldData;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Season = reader.ReadVarInt();
            Weather = reader.ReadVarInt();
            CurrentTime = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            writer.WriteVarInt(Season);
            writer.WriteVarInt(Weather);
            writer.WriteString(CurrentTime);

            return this;
        }
    }
}
