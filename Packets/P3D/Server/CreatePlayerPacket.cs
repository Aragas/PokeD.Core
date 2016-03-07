using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Server
{
    public class CreatePlayerPacket : P3DPacket
    {
        public int PlayerID { get { return int.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0]); } set { DataItems[0] = value.ToString(); } }


        public override int ID => (int) P3DPacketTypes.CreatePlayer;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            PlayerID = reader.Read(PlayerID);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream writer)
        {
            writer.Write(PlayerID);

            return this;
        }
    }
}
