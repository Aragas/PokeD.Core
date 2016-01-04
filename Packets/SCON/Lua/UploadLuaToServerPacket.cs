using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Lua
{
    public class UploadLuaToServerPacket : SCONPacket
    {
        public string LuaFile { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.UploadLuaToServer;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            LuaFile = reader.Read(LuaFile);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(LuaFile);

            return this;
        }
    }
}
