using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerInfoListResponsePacket : SCONPacket
    {
        public PlayerInfo[] PlayerInfos { get; set; }

        public override VarInt ID => SCONPacketTypes.PlayerInfoListResponse;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PlayerInfos = reader.Read(PlayerInfos);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(PlayerInfos);

            return this;
        }
    }
}
