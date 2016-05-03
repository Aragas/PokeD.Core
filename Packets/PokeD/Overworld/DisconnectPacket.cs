using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld
{
    public class DisconnectPacket : PokeDPacket
    {
        public string Reason { get; set; } = string.Empty;


        public override VarInt ID => PokeDPacketTypes.Disconnect;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Reason = reader.Read(Reason);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(Reason);

            return this;
        }
    }
}
