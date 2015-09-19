using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerListResponsePacket : ProtobufPacket
    {
        public string[] Players { get; set; }

        public override int ID => (int) SCONPacketTypes.PlayerListResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            int length = reader.ReadVarInt();
            Players = reader.ReadStringArray(length);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteVarInt(Players.Length);
            stream.WriteStringArray(Players);

            return this;
        }
    }
}
