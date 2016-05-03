using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.PokeD.Structs;

namespace PokeD.Core.Packets.PokeD.Overworld
{
    public class PositionPacket : PokeDPacket
    {
        private MetaPosition Info { get; set; }

        public Vector3 Position { get { return Info.Position; } set { Info = new MetaPosition(value); } }


        public override VarInt ID => PokeDPacketTypes.Position;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Info = reader.Read(Info);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(Info);

            return this;
        }
    }
}
