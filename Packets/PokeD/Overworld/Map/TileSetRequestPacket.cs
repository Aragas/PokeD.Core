using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld.Map
{
    public class TileSetRequestPacket : PokeDPacket
    {
        public string[] TileSetNames { get; set; } = new string[0];


        public override VarInt ID => PokeDPacketTypes.TileSetRequest;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            TileSetNames = deserialiser.Read(TileSetNames);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(TileSetNames);
        }
    }
}
