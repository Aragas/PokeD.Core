using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogFileRequestPacket : ProtobufPacket
    {
        public string CrashLogFilename;

        public override VarInt ID => (int) SCONPacketTypes.CrashLogFileRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            CrashLogFilename = reader.Read(CrashLogFilename);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(CrashLogFilename);

            return this;
        }
    }
}
