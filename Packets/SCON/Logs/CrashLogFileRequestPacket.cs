using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogFileRequestPacket : SCONPacket
    {
        public string CrashLogFilename { get; set; } = string.Empty;


        public override VarInt ID => SCONPacketTypes.CrashLogFileRequest;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            CrashLogFilename = reader.Read(CrashLogFilename);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(CrashLogFilename);

            return this;
        }
    }
}
