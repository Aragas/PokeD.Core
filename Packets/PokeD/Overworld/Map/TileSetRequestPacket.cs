using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld.Map
{
    public class TileSetRequestPacket : PokeDPacket
    {
        public string[] TileSetNames { get; set; }


        public override VarInt ID => PokeDPacketTypes.TileSetRequest;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            TileSetNames = reader.Read(TileSetNames);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(TileSetNames);
           
            return this;
        }
    }
}
