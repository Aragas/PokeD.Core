using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.Structs;

namespace PokeD.Core.Packets.SCON.Status
{
    public class BanListResponsePacket : ProtobufPacket
    {
        public BanList BanList { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.BanListResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            BanList = BanList.FromReader(reader);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            BanList.ToStream(stream);

            return this;
        }
    }
}
