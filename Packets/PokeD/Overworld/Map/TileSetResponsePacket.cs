using System.Collections.Generic;

using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld.Map
{
    public class TileSetResponsePacket : PokeDPacket
    {
        public List<string> TileSets { get; set; } = new List<string>();
        public List<byte[]> Images { get; set; } = new List<byte[]>();


        public override VarInt ID => (int) PokeDPacketTypes.TileSetResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            var tileSetCount = reader.Read<VarInt>();
            for (var i = 0; i < tileSetCount; i++)
                TileSets.Add(reader.Read<string>());

            var imageCount = reader.Read<VarInt>();
            for (var i = 0; i < imageCount; i++)
                Images.Add(reader.Read<byte[]>());

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
