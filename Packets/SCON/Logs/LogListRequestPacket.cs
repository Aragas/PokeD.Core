using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogListRequestPacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.LogListRequest;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            return this;
        }
    }
}
