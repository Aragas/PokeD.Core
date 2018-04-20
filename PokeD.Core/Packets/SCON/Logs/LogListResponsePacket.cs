using Aragas.Network.IO;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogListResponsePacket : SCONPacket
    {
        public Log[] Logs { get; set; } = new Log[0];


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            Logs = deserialiser.Read(Logs);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(Logs);
        }
    }
}
