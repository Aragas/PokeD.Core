using Aragas.Network.Data;
using Aragas.Network.IO;

namespace PokeD.Core.Packets.SCON.Script
{
    public class UploadScriptToServerPacket : SCONPacket
    {
        public string ScriptFile { get; set; } = string.Empty;


        public override VarInt ID => SCONPacketTypes.UploadLuaToServer;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            ScriptFile = deserialiser.Read(ScriptFile);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(ScriptFile);
        }
    }
}
