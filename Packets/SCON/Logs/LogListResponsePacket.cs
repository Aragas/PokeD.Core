using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogListResponsePacket : SCONPacket
    {
        public Log[] Logs { get; set; }

        public override VarInt ID => SCONPacketTypes.LogListResponse;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Logs = reader.Read(Logs);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(Logs);

            return this;
        }
    }
}
