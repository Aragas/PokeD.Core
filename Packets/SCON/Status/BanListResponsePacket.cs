using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

using PokeD.Core.Data.Structs;

namespace PokeD.Core.Packets.SCON.Status
{
    public class BanListResponsePacket : ProtobufPacket
    {
        public BanList BanList { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.BanListResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            BanList = BanList.FromReader(reader);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            BanList.ToStream(stream);

            return this;
        }
    }
}
