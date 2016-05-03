using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogListResponsePacket : SCONPacket
    {
        public Log[] Logs { get; set; } = new Log[0];


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
