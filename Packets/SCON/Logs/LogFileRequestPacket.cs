using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileRequestPacket : ProtobufPacket
    {
        public string LogFilename { get; set; }

        public override int ID => (int) SCONPacketTypes.LogFileRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            LogFilename = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(LogFilename);

            return this;
        }
    }
}
