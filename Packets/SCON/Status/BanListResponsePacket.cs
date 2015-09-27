using PokeD.Core.Data.Structs;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class BanListResponsePacket : ProtobufPacket
    {
        public BanList BanList { get; set; }

        public override int ID => (int) SCONPacketTypes.BanListResponse;

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
