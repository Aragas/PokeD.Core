using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Server
{
    public class ServerMessagePacket : P3DPacket
    {
        public string Message { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) P3DPacketTypes.ServerMessage;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            Message = reader.Read(Message);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream writer)
        {
            writer.Write(Message);

            return this;
        }
    }
}
