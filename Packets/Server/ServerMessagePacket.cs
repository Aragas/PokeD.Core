using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Server
{
    public class ServerMessagePacket : Packet
    {
        public string Message { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) PlayerPacketTypes.ServerMessage;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            Message = reader.ReadString();

            return this;
        }

        public override Packet WritePacket(IPacketStream writer)
        {
            writer.WriteString(Message);

            return this;
        }
    }
}
