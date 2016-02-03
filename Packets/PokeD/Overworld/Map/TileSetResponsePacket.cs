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
        public List<TileSetResponse> TileSets { get; set; } = new List<TileSetResponse>();
        public List<ImageResponse> Images { get; set; } = new List<ImageResponse>();


        public override VarInt ID => (int)PokeDPacketTypes.TileSetResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            var tileSetCount = reader.Read<VarInt>();
            for (var i = 0; i < tileSetCount; i++)
                TileSets.Add(reader.Read<TileSetResponse>());

            var imageCount = reader.Read<VarInt>();
            for (var i = 0; i < imageCount; i++)
                Images.Add(reader.Read<ImageResponse>());

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(new VarInt(TileSets.Count));
            for (var i = 0; i < TileSets.Count; i++)
                writer.Write(TileSets[i]);

            writer.Write(new VarInt(Images.Count));
            for (var i = 0; i < Images.Count; i++)
                writer.Write(Images[i]);

            return this;
        }
    }
}
