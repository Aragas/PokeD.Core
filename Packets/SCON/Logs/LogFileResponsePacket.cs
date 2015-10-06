using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileResponsePacket : ProtobufPacket
    {
        public string LogFilename;
        public string LogFile;

        public override VarInt ID => (int) SCONPacketTypes.LogFileResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            LogFilename = reader.Read(LogFilename);
            LogFile = reader.Read(LogFile);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(LogFilename);
            stream.Write(LogFile);

            return this;
        }
    }
}
