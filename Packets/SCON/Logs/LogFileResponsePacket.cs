using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileResponsePacket : ProtobufPacket
    {
        public string LogFilename { get; set; }
        public string LogFile { get; set; }

        public override int ID => (int) SCONPacketTypes.LogFileResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            LogFilename = reader.ReadString();
            LogFile = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(LogFilename);
            stream.WriteString(LogFile);

            return this;
        }
    }
}
