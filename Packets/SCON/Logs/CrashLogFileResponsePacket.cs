using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogFileResponsePacket : ProtobufPacket
    {
        public string CrashLogFilename { get; set; }
        public string CrashLogFile { get; set; }

        public override int ID => (int) SCONPacketTypes.CrashLogFileResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            CrashLogFilename = reader.ReadString();
            CrashLogFile = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(CrashLogFilename);
            stream.WriteString(CrashLogFile);

            return this;
        }
    }
}
