using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Server
{
    public class WorldDataPacket : P3DPacket
    {
        public VarInt Season { get { return VarInt.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public VarInt Weather { get { return VarInt.Parse(DataItems[1], CultureInfo); } set { DataItems[1] = value.ToString(CultureInfo); } }
        public string CurrentTime { get { return DataItems[2]; } set { DataItems[2] = value; } }


        public override VarInt ID => (int) GamePacketTypes.WorldData;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Season = reader.Read(Season);
            Weather = reader.Read(Weather);
            CurrentTime = reader.Read(CurrentTime);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            writer.Write(Season);
            writer.Write(Weather);
            writer.Write(CurrentTime);

            return this;
        }
    }
}
