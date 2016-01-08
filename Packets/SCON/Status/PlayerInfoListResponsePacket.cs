using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.SCON;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerInfoListResponsePacket : SCONPacket
    {
        public PlayerInfo[] PlayerInfos { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.PlayerInfoListResponse;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            PlayerInfos = reader.Read(PlayerInfos);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(PlayerInfos);

            return this;
        }
    }
}
