using Aragas.Network.Data;
using Aragas.Network.IO;

using PokeD.Core.Data.PokeD;

namespace PokeD.Core.Packets.PokeD.Trade
{
    public class TradeOfferPacket : PokeDPacket
    {
        public VarInt DestinationID { get; set; }
        public Monster MonsterData { get; set; } // TODO: null


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            DestinationID = deserialiser.Read(DestinationID);
            MonsterData = deserialiser.Read(MonsterData);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(DestinationID);
            serializer.Write(MonsterData);
        }
    }
}
