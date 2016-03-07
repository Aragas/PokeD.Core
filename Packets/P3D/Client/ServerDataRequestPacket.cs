using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Client
{
    public class ServerDataRequestPacket : P3DPacket
    {
        public string DontEvenKnow { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) P3DPacketTypes.ServerDataRequest;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            DontEvenKnow = reader.Read(DontEvenKnow);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream writer)
        {
            writer.Write(DontEvenKnow);

            return this;
        }
    }
}
