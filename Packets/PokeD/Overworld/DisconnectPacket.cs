using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld
{
    public class DisconnectPacket : PokeDPacket
    {
        public string Reason { get; set; }


        public override VarInt ID => (int) PokeDPacketTypes.Disconnect;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Reason = reader.Read(Reason);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(Reason);

            return this;
        }
    }
}
