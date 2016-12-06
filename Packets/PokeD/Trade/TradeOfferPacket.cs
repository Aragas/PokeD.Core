using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.PokeD.Monster;

namespace PokeD.Core.Packets.PokeD.Trade
{
    public class TradeOfferPacket : PokeDPacket
    {
        public VarInt DestinationId { get; set; }
        public MonsterInstanceData MonsterData { get; set; } = new MonsterInstanceData(1);


        public override VarInt ID => PokeDPacketTypes.TradeOffer;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            DestinationId = reader.Read(DestinationId);
            MonsterData = reader.Read(MonsterData);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(DestinationId);
            writer.Write(MonsterData);

            return this;
        }
    }
}
