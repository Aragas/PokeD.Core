using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.Structs;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogListResponsePacket : ProtobufPacket
    {
        public LogList LogList { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.LogListResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            LogList = LogList.FromReader(reader);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            LogList.ToStream(stream);

            return this;
        }
    }
}
