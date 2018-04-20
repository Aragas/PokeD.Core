using Aragas.Network.IO;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileRequestPacket : SCONPacket
    {
        public string LogFilename { get; set; } = string.Empty;


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            LogFilename = deserialiser.Read(LogFilename);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(LogFilename);
        }
    }
}
