using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerDatabaseListRequestPacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.PlayerDatabaseListRequest;

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
