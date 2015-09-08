using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Client
{
    public class ServerDataRequestPacket : Packet
    {
        public string DontEvenKnow { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) PlayerPacketTypes.ServerDataRequest;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            DontEvenKnow = reader.ReadString();

            return this;
        }

        public override Packet WritePacket(IPacketStream writer)
        {
            writer.WriteString(DontEvenKnow);

            return this;
        }
    }
}
