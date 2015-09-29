using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogFileResponsePacket : ProtobufPacket
    {
        public string CrashLogFilename { get; set; }
        public string CrashLogFile { get; set; }

        public override int ID => (int) SCONPacketTypes.CrashLogFileResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            CrashLogFile = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(CrashLogFile);

            return this;
        }
    }
}
