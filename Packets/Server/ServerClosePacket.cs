using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Server
{
    public class ServerClosePacket : Packet
    {
        public string Reason { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) PlayerPacketTypes.ServerClose;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            Reason = reader.ReadString();

            return this;
        }

        public override Packet WritePacket(IPacketStream writer)
        {
            writer.WriteString(Reason);

            return this;
        }
    }
}
