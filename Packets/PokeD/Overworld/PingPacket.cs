using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld
{
    public class PingPacket : PokeDPacket
    {
        public override VarInt ID => (int) PokeDPacketTypes.Ping;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            return this;
        }
    }
}
