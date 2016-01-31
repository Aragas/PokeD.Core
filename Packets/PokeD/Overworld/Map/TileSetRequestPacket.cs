using System.Collections.Generic;

using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld.Map
{
    public class TileSetRequestPacket : PokeDPacket
    {
        public List<string> TileSetNames { get; set; } = new List<string>();


        public override VarInt ID => (int) PokeDPacketTypes.TileSetRequest;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            var tileSetNameCount = reader.Read<VarInt>();
            for (var i = 0; i < tileSetNameCount; i++)
                TileSetNames.Add(reader.Read<string>());
            
            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(new VarInt(TileSetNames.Count));
            for (var i = 0; i < TileSetNames.Count; i++)
                writer.Write(TileSetNames[i]);
           
            return this;
        }
    }
}
