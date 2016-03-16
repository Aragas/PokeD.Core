using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogListResponsePacket : SCONPacket
    {
        public Log[] CrashLogs { get; set; }

        public override VarInt ID => SCONPacketTypes.CrashLogListResponse;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            CrashLogs = reader.Read(CrashLogs);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(CrashLogs);

            return this;
        }
    }
}
