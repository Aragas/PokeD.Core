using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerListResponsePacket : Packet
    {
        public string[] Players { get; set; }

        public override int ID => (int) SCONPacketTypes.PlayerListResponse;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            int length = reader.ReadVarInt();
            Players = reader.ReadStringArray(length);

            return this;
        }

        public override Packet WritePacket(IPacketStream stream)
        {
            stream.WriteVarInt(Players.Length);
            stream.WriteStringArray(Players);

            return this;
        }
    }
}
