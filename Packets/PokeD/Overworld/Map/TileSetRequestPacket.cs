using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld.Map
{
    public class TileSetRequestPacket : PokeDPacket
    {
        public string[] TileSetNames { get; set; }


        public override VarInt ID => (int) PokeDPacketTypes.TileSetRequest;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            TileSetNames = new string[reader.Read<VarInt>()];
            for (var i = 0; i < TileSetNames.Length; i++)
                TileSetNames[i] = reader.Read<string>();
            
            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(new VarInt(TileSetNames.Length));
            for (var i = 0; i < TileSetNames.Length; i++)
                writer.Write(TileSetNames[i]);
           
            return this;
        }
    }
}
