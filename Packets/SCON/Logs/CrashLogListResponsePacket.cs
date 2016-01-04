using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;
using PokeD.Core.Data.SCON;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogListResponsePacket : SCONPacket
    {
        public Log[] CrashLogs { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.CrashLogListResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            CrashLogs = reader.Read(CrashLogs);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(CrashLogs);

            return this;
        }
    }
}
