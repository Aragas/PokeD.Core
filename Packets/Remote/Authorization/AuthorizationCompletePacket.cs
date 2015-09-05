using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Remote.Authorization
{
    public class AuthorizationCompletePacket : IPacket
    {
        public override int ID => (int) RemotePacketTypes.AuthorizationCompletePacket;

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
