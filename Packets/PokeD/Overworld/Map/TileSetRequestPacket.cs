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
            TileSetNames = reader.Read(TileSetNames);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(TileSetNames);
           
            return this;
        }
    }
}
