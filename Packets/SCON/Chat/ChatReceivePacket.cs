using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class ChatReceivePacket : SCONPacket
    {
        public bool Enabled { get; set; }


        public override VarInt ID => SCONPacketTypes.ChatReceivePacket;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            Enabled = deserialiser.Read(Enabled);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(Enabled);
        }
    }
}
