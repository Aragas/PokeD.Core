using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld.Map
{
    public class TileSetResponse
    {
        public string Name { get; set; } = string.Empty;
        public string TileSetData { get; set; } = string.Empty;
    }
    public class ImageResponse
    {
        public string Name { get; set; } = string.Empty;
        public byte[] ImageData { get; set; } = new byte[0];
    }

    public class TileSetResponsePacket : PokeDPacket
    {
        public TileSetResponse[] TileSets { get; set; } = new TileSetResponse[0];
        public ImageResponse[] Images { get; set; } = new ImageResponse[0];


        public override VarInt ID => PokeDPacketTypes.TileSetResponse;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            TileSets = reader.Read(TileSets);
            Images = reader.Read(Images);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(TileSets);
            writer.Write(Images);

            return this;
        }
    }
}
