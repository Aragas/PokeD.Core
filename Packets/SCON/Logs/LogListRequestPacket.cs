using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogListRequestPacket : ProtobufPacket
    {
        public override int ID => (int) SCONPacketTypes.LogListRequest;

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
