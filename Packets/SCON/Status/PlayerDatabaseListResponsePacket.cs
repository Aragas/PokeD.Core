using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerDatabaseListResponsePacket : SCONPacket
    {
        public PlayerDatabase[] PlayerDatabases { get; set; }

        public override VarInt ID => SCONPacketTypes.PlayerDatabaseListResponse;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PlayerDatabases = reader.Read(PlayerDatabases);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(PlayerDatabases);

            return this;
        }
    }
}
