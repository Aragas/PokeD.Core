using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileResponsePacket : ProtobufPacket
    {
        public string LogFile { get; set; }

        public override int ID => (int) SCONPacketTypes.LogFileResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            LogFile = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(LogFile);

            return this;
        }
    }
}
