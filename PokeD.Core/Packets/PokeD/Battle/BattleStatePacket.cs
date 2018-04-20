using Aragas.Network.IO;

using PokeD.BattleEngine.Battle;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Server
    /// </summary>
    public class BattleStatePacket : PokeDPacket
    {
        public BattleState BattleState { get; set; }


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            BattleState = deserialiser.Read(BattleState);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(BattleState);
        }
    }
}
