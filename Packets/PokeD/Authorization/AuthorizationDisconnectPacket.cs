using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class AuthorizationDisconnectPacket : PokeDPacket
    {
        public string Reason { get; set; } = string.Empty;


        public override VarInt ID => PokeDPacketTypes.AuthorizationDisconnect;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Reason = reader.Read(Reason);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(Reason);

            return this;
        }
    }
}
