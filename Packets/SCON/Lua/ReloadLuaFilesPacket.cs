using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Lua
{
    public class ReloadNPCsPacket : ProtobufPacket
    {
        public override VarInt ID => (int) SCONPacketTypes.ReloadNPCs;

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
