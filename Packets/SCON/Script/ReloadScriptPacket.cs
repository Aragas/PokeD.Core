using Aragas.Network.Data;
using Aragas.Network.IO;

namespace PokeD.Core.Packets.SCON.Script
{
    public class ReloadScriptPacket : SCONPacket
    {
        public override VarInt ID => SCONPacketTypes.ReloadNPCs;

        public override void Deserialize(ProtobufDeserialiser deserialiser) { }
        public override void Serialize(ProtobufSerializer serializer) { }
    }
}
