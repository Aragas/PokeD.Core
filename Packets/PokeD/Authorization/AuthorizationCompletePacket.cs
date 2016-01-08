using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class AuthorizationCompletePacket : PokeDPacket
    {
        public VarInt PlayerID { get; set; }


        public override VarInt ID => (int) PokeDPacketTypes.AuthorizationComplete;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            PlayerID = reader.Read(PlayerID);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(PlayerID);

            return this;
        }
    }
}
