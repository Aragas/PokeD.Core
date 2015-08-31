using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Server
{
    public class ServerClosePacket : IPacket
    {
        public string Reason { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID { get { return (int) PlayerPacketTypes.ServerClose; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            Reason = reader.ReadString();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteString(Reason);

            return this;
        }
    }
}
