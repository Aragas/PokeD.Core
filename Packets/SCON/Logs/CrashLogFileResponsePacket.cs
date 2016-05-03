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

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            CrashLogFilename = reader.Read(CrashLogFilename);
            CrashLogFile = reader.Read(CrashLogFile);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(CrashLogFilename);
            stream.Write(CrashLogFile);

            return this;
        }
    }
}
