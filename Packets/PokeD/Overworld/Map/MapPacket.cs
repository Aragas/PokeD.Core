using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld.Map
{
    public class FileHash
    {
        public string Name { get; set; }
        public string Hash { get; set; }
    }

    public class MapPacket : PokeDPacket
    {
        public string MapData { get; set; }
        public FileHash[] TileSetHashes { get; set; }
        public FileHash[] ImageHashes { get; set; }


        public override VarInt ID => PokeDPacketTypes.Map;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            MapData = reader.Read(MapData);
            TileSetHashes = reader.Read(TileSetHashes);
            ImageHashes = reader.Read(ImageHashes);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(MapData);
            writer.Write(TileSetHashes);
            writer.Write(ImageHashes);

            return this;
        }
    }
}
