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


        public override VarInt ID => (int) PokeDPacketTypes.Map;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            MapData = reader.Read(MapData);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(MapData);

            return this;
        }
    }
}
