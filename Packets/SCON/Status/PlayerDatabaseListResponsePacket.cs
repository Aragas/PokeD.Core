using PokeD.Core.Data.Structs;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

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
