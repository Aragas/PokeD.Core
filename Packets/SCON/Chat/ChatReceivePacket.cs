using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class ChatReceivePacket : SCONPacket
    {
        public bool Enabled { get; set; }


        public override VarInt ID => SCONPacketTypes.ChatReceivePacket;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Enabled = reader.Read(Enabled);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(Enabled);

            return this;
        }
    }
}
