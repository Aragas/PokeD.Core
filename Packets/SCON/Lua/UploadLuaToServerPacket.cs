using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Lua
{
    public class UploadLuaToServerPacket : SCONPacket
    {
        public string LuaFile { get; set; } = string.Empty;


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
