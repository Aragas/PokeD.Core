using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD
{
    public abstract class PokeDPacket : PacketWithEnumName<VarInt, ProtobufSerializer, ProtobufDeserialiser>
    {

    }
}
