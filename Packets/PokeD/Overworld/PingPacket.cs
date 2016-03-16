using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld
{
    public class PingPacket : PokeDPacket
    {
        public override VarInt ID => PokeDPacketTypes.Ping;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            return this;
        }
    }
}
