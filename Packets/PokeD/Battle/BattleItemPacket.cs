using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.PokeD.Structs;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleItemPacket : PokeDPacket
    {
        private MetaItem Info { get; set; }

        public short Monster { get { return Info.Monster; } set { Info = new MetaItem(value, Item); } }
        public short Item { get { return Info.Item; } set { Info = new MetaItem(Monster, value); } }


        public override VarInt ID => PokeDPacketTypes.BattleItem;

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
