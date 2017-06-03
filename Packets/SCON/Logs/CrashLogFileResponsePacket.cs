using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogFileResponsePacket : SCONPacket
    {
        public string CrashLogFilename { get; set; } = string.Empty;
        public string CrashLogFile { get; set; } = string.Empty;


        public override VarInt ID => SCONPacketTypes.CrashLogFileResponse;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            CrashLogFilename = deserialiser.Read(CrashLogFilename);
            CrashLogFile = deserialiser.Read(CrashLogFile);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(CrashLogFilename);
            serializer.Write(CrashLogFile);
        }
    }
}
