using PokeD.Core.Data.Structs;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerDatabaseListResponsePacket : ProtobufPacket
    {
        public PlayerDatabaseList PlayerDatabaseList { get; set; }

        public override int ID => (int) SCONPacketTypes.PlayerDatabaseListResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            PlayerDatabaseList = PlayerDatabaseList.FromReader(reader);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            PlayerDatabaseList.ToStream(stream);

            return this;
        }
    }
}
