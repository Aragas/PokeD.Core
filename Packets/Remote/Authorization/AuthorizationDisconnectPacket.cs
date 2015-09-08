using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Remote.Authorization
{
    public class AuthorizationDisconnectPacket : Packet
    {
        public string Reason { get; set; }

        public override int ID => (int) RemotePacketTypes.AuthorizationDisconnectPacket;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            Reason = reader.ReadString();

            return this;
        }

        public override Packet WritePacket(IPacketStream stream)
        {
            stream.WriteString(Reason);

            return this;
        }
    }
}
