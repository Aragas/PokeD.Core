using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Trade
{
    public class TradeQuitPacket : P3DPacket
    {
        public VarInt DestinationPlayerID { get { return VarInt.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }


        public override VarInt ID => (int) GamePacketTypes.TradeQuit;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerID = reader.ReadVarInt();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            if (!writer.IsServer)
                writer.Write(DestinationPlayerID);

            return this;
        }
    }
}
