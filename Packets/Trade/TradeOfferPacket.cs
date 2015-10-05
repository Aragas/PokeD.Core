using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Trade
{
    public class TradeOfferPacket : P3DPacket
    {
        public VarInt DestinationPlayerID { get { return VarInt.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public string TradeData { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override VarInt ID => (int) GamePacketTypes.TradeOffer;

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
                writer.Write(DestinationPlayerID);
            writer.Write(TradeData);

            return this;
        }
    }
}
