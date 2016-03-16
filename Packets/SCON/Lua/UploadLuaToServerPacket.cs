using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Lua
{
    public class UploadLuaToServerPacket : SCONPacket
    {
        public string LuaFile { get; set; }

        public override VarInt ID => SCONPacketTypes.UploadLuaToServer;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            LuaFile = reader.Read(LuaFile);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(LuaFile);

            return this;
        }
    }
}
