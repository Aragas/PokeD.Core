using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Trade
{
    public class TradeRefusePacket : PokeDPacket
    {
        public VarInt DestinationID { get; set; }


        public override VarInt ID => PokeDPacketTypes.TradeRefuse;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            DestinationID = reader.Read(DestinationID);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(DestinationID);

            return this;
        }
    }
}
