using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.SCON;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogListResponsePacket : SCONPacket
    {
        public Log[] Logs { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.LogListResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Logs = reader.Read(Logs);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(Logs);

            return this;
        }
    }
}
