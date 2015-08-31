using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Client
{
    public class PingPacket : IPacket
    {
        public override int ID { get { return (int) PlayerPacketTypes.Ping; } }
        
        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            return this;
        }
    }
}
