using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;
using PokeD.Core.Data.SCON;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerDatabaseListResponsePacket : SCONPacket
    {
        public PlayerDatabase[] PlayerDatabases { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.PlayerDatabaseListResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            PlayerDatabases = reader.Read(PlayerDatabases);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(PlayerDatabases);

            return this;
        }
    }
}
