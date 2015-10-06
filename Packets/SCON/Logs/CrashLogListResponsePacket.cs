using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

using PokeD.Core.Data.Structs;

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
