using Aragas.Network.IO;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerDatabaseListResponsePacket : SCONPacket
    {
        public PlayerDatabase[] PlayerDatabases { get; set; } = new PlayerDatabase[0];


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            PlayerDatabases = deserialiser.Read(PlayerDatabases);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(PlayerDatabases);
        }
    }
}
