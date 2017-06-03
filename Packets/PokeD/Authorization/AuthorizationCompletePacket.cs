using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class AuthorizationCompletePacket : PokeDPacket
    {
        public VarInt PlayerID { get; set; }


        public override VarInt ID => PokeDPacketTypes.AuthorizationComplete;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            PlayerID = deserialiser.Read(PlayerID);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(PlayerID);
        }
    }
}
