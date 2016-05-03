using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogListResponsePacket : SCONPacket
    {
        public Log[] CrashLogs { get; set; } = new Log[0];


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
