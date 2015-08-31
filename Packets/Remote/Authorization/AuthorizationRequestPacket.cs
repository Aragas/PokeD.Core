using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Remote.Authorization
{
    public class AuthorizationRequestPacket : IPacket
    {
        public override int ID { get { return (int) RemotePacketTypes.AuthorizationRequestPacket; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            return this;
        }

        public override IPacket WritePacket(IPokeStream stream)
        {
            return this;
        }
    }
}
