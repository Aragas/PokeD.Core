using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleAcceptPacket : PokeDPacket
    {
        public bool IsAccepted { get; set; }


        public override VarInt ID => PokeDPacketTypes.BattleAccept;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            IsAccepted = deserialiser.Read(IsAccepted);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(IsAccepted);
        }
    }
}
