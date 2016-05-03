using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

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
