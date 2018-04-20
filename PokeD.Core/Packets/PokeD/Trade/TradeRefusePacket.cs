using Aragas.Network.Data;
using Aragas.Network.IO;

namespace PokeD.Core.Packets.PokeD.Trade
{
    public class TradeRefusePacket : PokeDPacket
    {
        public VarInt DestinationID { get; set; }


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            DestinationID = deserialiser.Read(DestinationID);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(DestinationID);
        }
    }
}
