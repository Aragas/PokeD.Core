using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Server
{
    public class WorldDataPacket : P3DPacket
    {
        public VarInt Season { get { return VarInt.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public VarInt Weather { get { return VarInt.Parse(DataItems[1] == string.Empty ? 0.ToString() : DataItems[1], CultureInfo); } set { DataItems[1] = value.ToString(CultureInfo); } }
        public string CurrentTime { get { return DataItems[2]; } set { DataItems[2] = value; } }


        public override VarInt ID => (int) GamePacketTypes.WorldData;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Season = reader.Read(Season);
            Weather = reader.Read(Weather);
            CurrentTime = reader.Read(CurrentTime);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(Season);
            writer.Write(Weather);
            writer.Write(CurrentTime);

            return this;
        }
    }
}
