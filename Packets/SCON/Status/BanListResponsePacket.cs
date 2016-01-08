using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.SCON;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.SCON.Status
{
    public class BanListResponsePacket : SCONPacket
    {
        public Ban[] Bans { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.BanListResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Bans = reader.Read(Bans);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(Bans);

            return this;
        }
    }
}
