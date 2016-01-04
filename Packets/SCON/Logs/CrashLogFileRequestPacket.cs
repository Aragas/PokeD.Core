using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogFileRequestPacket : SCONPacket
    {
        public string CrashLogFilename { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.CrashLogFileRequest;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            CrashLogFilename = reader.Read(CrashLogFilename);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(CrashLogFilename);

            return this;
        }
    }
}
