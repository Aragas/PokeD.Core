using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogFileRequestPacket : ProtobufPacket
    {
        public string CrashLogFilename { get; set; }

        public override int ID => (int) SCONPacketTypes.CrashLogFileRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            CrashLogFilename = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(CrashLogFilename);

            return this;
        }
    }
}
