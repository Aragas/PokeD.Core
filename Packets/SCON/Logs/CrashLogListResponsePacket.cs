using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.Structs;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogListResponsePacket : ProtobufPacket
    {
        public LogList CrashLogList { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.CrashLogListResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            CrashLogList = LogList.FromReader(reader);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            CrashLogList.ToStream(stream);

            return this;
        }
    }
}
