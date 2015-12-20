using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.Structs;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerDatabaseListResponsePacket : ProtobufPacket
    {
        public PlayerDatabaseList PlayerDatabaseList { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.PlayerDatabaseListResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            PlayerDatabaseList = PlayerDatabaseList.FromReader(reader);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            PlayerDatabaseList.ToStream(stream);

            return this;
        }
    }
}
