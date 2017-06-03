using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Server
    /// </summary>
    public class BattleOfferPacket : PokeDPacket
    {
        public VarInt[] PlayerIDs { get; set; } = new VarInt[0];
        public string Message { get; set; } = string.Empty;


        public override VarInt ID => PokeDPacketTypes.BattleOffer;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            PlayerIDs = deserialiser.Read(PlayerIDs);
            Message = deserialiser.Read(Message);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(PlayerIDs);
            serializer.Write(Message);
        }
    }
}
