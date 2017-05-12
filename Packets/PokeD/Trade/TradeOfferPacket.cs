using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.PokeD;

namespace PokeD.Core.Packets.PokeD.Trade
{
    public class TradeOfferPacket : PokeDPacket
    {
        public VarInt DestinationID { get; set; }
        public Monster MonsterData { get; set; } // TODO: null


        public override VarInt ID => PokeDPacketTypes.TradeOffer;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            DestinationID = reader.Read(DestinationID);
            MonsterData = reader.Read(MonsterData);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(DestinationID);
            writer.Write(MonsterData);

            return this;
        }
    }
}
