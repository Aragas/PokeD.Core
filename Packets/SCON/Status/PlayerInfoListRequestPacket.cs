using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerInfoListRequestPacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.PlayerInfoListRequest;

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
