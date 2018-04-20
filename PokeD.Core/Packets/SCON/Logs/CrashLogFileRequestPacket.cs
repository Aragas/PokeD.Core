using Aragas.Network.IO;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogFileRequestPacket : SCONPacket
    {
        public string CrashLogFilename { get; set; } = string.Empty;


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            CrashLogFilename = deserialiser.Read(CrashLogFilename);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(CrashLogFilename);
        }
    }
}
