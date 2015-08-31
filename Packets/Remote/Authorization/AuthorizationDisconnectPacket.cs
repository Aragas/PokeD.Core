using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Remote.Authorization
{
    public class AuthorizationDisconnectPacket : IPacket
    {
        public string Reason { get; set; }

        public override int ID { get { return (int) RemotePacketTypes.AuthorizationDisconnectPacket; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            Reason = reader.ReadString();

            return this;
        }

        public override IPacket WritePacket(IPokeStream stream)
        {
            stream.WriteString(Reason);

            return this;
        }
    }
}
