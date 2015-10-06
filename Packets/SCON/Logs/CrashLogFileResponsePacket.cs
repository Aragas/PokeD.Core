using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogFileResponsePacket : ProtobufPacket
    {
        public string CrashLogFilename;
        public string CrashLogFile;

        public override VarInt ID => (int) SCONPacketTypes.CrashLogFileResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            CrashLogFilename = reader.Read(CrashLogFilename);
            CrashLogFile = reader.Read(CrashLogFile);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(CrashLogFilename);
            stream.Write(CrashLogFile);

            return this;
        }
    }
}
