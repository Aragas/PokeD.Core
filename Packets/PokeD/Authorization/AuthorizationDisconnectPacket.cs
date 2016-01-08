using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class AuthorizationDisconnectPacket : PokeDPacket
    {
        public string Reason { get; set; }


        public override VarInt ID => (int) PokeDPacketTypes.AuthorizationDisconnect;

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
