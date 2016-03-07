using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Server
{
    public class KickedPacket : P3DPacket
    {
        public string Reason { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) P3DPacketTypes.Kicked;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            Reason = reader.Read(Reason);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream writer)
        {
            writer.Write(Reason);

            return this;
        }
    }
}
