using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Shared
{
    public class GameStateMessagePacket : P3DPacket
    {
        public string EventMessage {  get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) P3DPacketTypes.GameStateMessage;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            EventMessage = reader.Read(EventMessage);

            return this;
        }

        public override P3DPacket WritePacket(PacketStream writer)
        {
            writer.Write(EventMessage);

            return this;
        }
    }
}
