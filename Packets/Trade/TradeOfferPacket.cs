using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Trade
{
    public class TradeOfferPacket : P3DPacket
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public string TradeData { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override int ID => (int) GamePacketTypes.TradeOffer;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerID = reader.ReadVarInt();
            TradeData = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            if (!writer.IsServer)
                writer.WriteVarInt(DestinationPlayerID);
            writer.WriteString(TradeData);

            return this;
        }
    }
}
