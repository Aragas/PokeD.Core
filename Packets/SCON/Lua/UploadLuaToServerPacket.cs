using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Lua
{
    public class UploadLuaToServerPacket : ProtobufPacket
    {
        public string LuaFile;

        public override VarInt ID => (int) SCONPacketTypes.UploadLuaToServer;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            LuaFile = reader.Read(LuaFile);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(LuaFile);

            return this;
        }
    }
}
