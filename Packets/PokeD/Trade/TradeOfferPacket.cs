using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.PokeD.Monster;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.PokeD.Trade
{
    public class TradeOfferPacket : PokeDPacket
    {
        public VarInt DestinationID { get; set; }
        public MonsterInstanceData MonsterData { get; set; }


        public override VarInt ID => (int) PokeDPacketTypes.TradeOffer;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            DestinationID = reader.Read(DestinationID);
            MonsterData = reader.Read(MonsterData);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(DestinationID);
            writer.Write(MonsterData);

            return this;
        }
    }
}
