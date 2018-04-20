using Aragas.Network.IO;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileResponsePacket : SCONPacket
    {
        public string LogFilename { get; set; } = string.Empty;
        public string LogFile { get; set; } = string.Empty;


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            LogFilename = deserialiser.Read(LogFilename);
            LogFile = deserialiser.Read(LogFile);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(LogFilename);
            serializer.Write(LogFile);
        }
    }
}
