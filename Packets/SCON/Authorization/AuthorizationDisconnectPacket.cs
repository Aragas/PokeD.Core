using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationDisconnectPacket : ProtobufPacket
    {
        public string Reason;

        public override VarInt ID => (int) SCONPacketTypes.AuthorizationDisconnect;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Reason = reader.Read(Reason);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(Reason);

            return this;
        }
    }
}
