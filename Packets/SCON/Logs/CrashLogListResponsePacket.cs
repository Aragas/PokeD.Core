using Aragas.Core.Data;
using PokeD.Core.Data.Structs;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogListResponsePacket : ProtobufPacket
    {
        public LogList CrashLogList { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.CrashLogListResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            CrashLogList = LogList.FromReader(reader);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            CrashLogList.ToStream(stream);

            return this;
        }
    }
}
