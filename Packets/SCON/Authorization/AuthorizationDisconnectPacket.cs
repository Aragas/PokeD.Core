using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationDisconnectPacket : ProtobufPacket
    {
        public string Reason { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.AuthorizationDisconnect;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Reason = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(Reason);

            return this;
        }
    }
}
