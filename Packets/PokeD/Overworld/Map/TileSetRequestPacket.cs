using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld.Map
{
    public class TileSetRequestPacket : PokeDPacket
    {
        public string[] TileSetNames { get; set; } = new string[0];


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
