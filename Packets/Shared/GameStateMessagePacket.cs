using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Shared
{
    public class GameStateMessagePacket : Packet
    {
        public string EventMessage {  get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) PlayerPacketTypes.GameStateMessage;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            EventMessage = reader.ReadString();

            return this;
        }

        public override Packet WritePacket(IPacketStream writer)
        {
            writer.WriteString(EventMessage);

            return this;
        }
    }
}
