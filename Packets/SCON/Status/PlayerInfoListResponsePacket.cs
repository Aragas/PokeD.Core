using PokeD.Core.Data.Structs;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerInfoListResponsePacket : ProtobufPacket
    {
        public PlayerInfoList PlayerInfoList { get; set; }

        public override int ID => (int) SCONPacketTypes.PlayerInfoListResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            PlayerInfoList = PlayerInfoList.FromReader(reader);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            PlayerInfoList.ToStream(stream);

            return this;
        }
    }
}
