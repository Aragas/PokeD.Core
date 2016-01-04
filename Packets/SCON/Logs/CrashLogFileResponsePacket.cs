using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogFileResponsePacket : SCONPacket
    {
        public string CrashLogFilename { get; set; }
        public string CrashLogFile { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.CrashLogFileResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            CrashLogFilename = reader.Read(CrashLogFilename);
            CrashLogFile = reader.Read(CrashLogFile);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(CrashLogFilename);
            stream.Write(CrashLogFile);

            return this;
        }
    }
}
