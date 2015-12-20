using Aragas.Core.Data;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets
{
    public abstract class ProtobufOriginPacket : ProtobufPacket
    {
        public VarInt Origin { get; set; }
    }
}
