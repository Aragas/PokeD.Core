using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerLocationRequestPacket : ProtobufPacket
    {
        public string Player { get; set; }

        public override int ID => (int) SCONPacketTypes.PlayerListRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            return this;
        }
    }
}
