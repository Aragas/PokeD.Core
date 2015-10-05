using Aragas.Core.Data;
using PokeD.Core.Data.Structs;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerInfoListResponsePacket : ProtobufPacket
    {
        public PlayerInfoList PlayerInfoList { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.PlayerInfoListResponse;

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
