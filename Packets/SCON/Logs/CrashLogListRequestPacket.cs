using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogListRequestPacket : ProtobufPacket
    {
        public override int ID => (int) SCONPacketTypes.CrashLogListRequest;

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
