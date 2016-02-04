using System.Collections.Generic;

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
            TileSets = new TileSetResponse[reader.Read<VarInt>()];
            for (var i = 0; i < TileSets.Length; i++)
                TileSets[i] = reader.Read<TileSetResponse>();

            Images = new ImageResponse[reader.Read<VarInt>()];
            for (var i = 0; i < Images.Length; i++)
                Images[i] = reader.Read<ImageResponse>();

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(new VarInt(TileSets.Length));
            for (var i = 0; i < TileSets.Length; i++)
                writer.Write(TileSets[i]);

            writer.Write(new VarInt(Images.Length));
            for (var i = 0; i < Images.Length; i++)
                writer.Write(Images[i]);

            return this;
        }
    }
}
