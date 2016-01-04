using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileResponsePacket : SCONPacket
    {
        public string LogFilename { get; set; }
        public string LogFile { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.LogFileResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            LogFilename = reader.Read(LogFilename);
            LogFile = reader.Read(LogFile);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(LogFilename);
            stream.Write(LogFile);

            return this;
        }
    }
}
