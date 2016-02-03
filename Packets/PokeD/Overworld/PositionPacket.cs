using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.PokeD.Structs;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.PokeD.Overworld
{
    public class PositionPacket : PokeDPacket
    {
        private MetaPosition Info { get; set; }

        public Vector3 Position { get { return Info.Position; } set { Info = new MetaPosition(value); } }


        public override VarInt ID => (int) PokeDPacketTypes.Position;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Info = reader.Read(Info);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(Info);

            return this;
        }
    }
}
