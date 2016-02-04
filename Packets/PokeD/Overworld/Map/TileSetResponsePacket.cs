using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.PokeD.Overworld.Map
{
    public class TileSetResponse
    {
        public string Name { get; set; }
        public string TileSetData { get; set; }
    }
    public class ImageResponse
    {
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
    }

    public class TileSetResponsePacket : PokeDPacket
    {
        public TileSetResponse[] TileSets { get; set; }
        public ImageResponse[] Images { get; set; }


        public override VarInt ID => (int)PokeDPacketTypes.TileSetResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            TileSets = reader.Read(TileSets);
            Images = reader.Read(Images);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(TileSets);
            writer.Write(Images);

            return this;
        }
    }
}
