using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileResponsePacket : SCONPacket
    {
        public string LogFilename { get; set; } = string.Empty;
        public string LogFile { get; set; } = string.Empty;


        public override VarInt ID => SCONPacketTypes.LogFileResponse;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            LogFilename = reader.Read(LogFilename);
            LogFile = reader.Read(LogFile);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(LogFilename);
            stream.Write(LogFile);

            return this;
        }
    }
}
