using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class AuthorizationRequestPacket : PokeDPacket
    {
        public string Name { get; set; }

        public override VarInt ID => (int) PokeDPacketTypes.AuthorizationRequest;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Name = reader.Read(Name);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(Name);

            return this;
        }
    }
}
