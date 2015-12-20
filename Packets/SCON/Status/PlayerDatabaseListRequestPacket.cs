using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerDatabaseListRequestPacket : ProtobufPacket
    {
        public override VarInt ID => (int) SCONPacketTypes.PlayerDatabaseListRequest;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            return this;
        }
    }
}
