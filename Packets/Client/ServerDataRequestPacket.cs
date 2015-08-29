using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Client
{
    public class ServerDataRequestPacket : IPacket
    {
        public string DontEvenKnow { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID { get { return (int) PacketTypes.ServerDataRequest; } }
        
        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            DontEvenKnow = reader.ReadString();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteString(DontEvenKnow);

            return this;
        }
    }
}
