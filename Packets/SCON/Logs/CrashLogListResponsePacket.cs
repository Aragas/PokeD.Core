using PokeD.Core.Data.Structs;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogListResponsePacket : ProtobufPacket
    {
        public LogList CrashLogList { get; set; }

        public override int ID => (int) SCONPacketTypes.CrashLogListResponse;

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
