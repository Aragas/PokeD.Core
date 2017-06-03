using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld.Map
{
    public class FileHash
    {
        public string Name { get; set; } = string.Empty;
        public string Hash { get; set; } = string.Empty;
    }

    public class MapPacket : PokeDPacket
    {
        public string MapData { get; set; } = string.Empty;
        public FileHash[] TileSetHashes { get; set; } = new FileHash[0];
        public FileHash[] ImageHashes { get; set; } = new FileHash[0];


        public override VarInt ID => PokeDPacketTypes.Map;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            MapData = deserialiser.Read(MapData);
            TileSetHashes = deserialiser.Read(TileSetHashes);
            ImageHashes = deserialiser.Read(ImageHashes);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(MapData);
            serializer.Write(TileSetHashes);
            serializer.Write(ImageHashes);
        }
    }
}
