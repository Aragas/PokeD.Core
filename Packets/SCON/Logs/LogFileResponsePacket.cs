using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileResponsePacket : ProtobufPacket
    {
        public string LogFilename { get; set; }
        public string LogFile { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.LogFileResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            LogFilename = reader.ReadString();
            LogFile = reader.ReadString();

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
