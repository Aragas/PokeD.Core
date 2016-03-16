using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class AuthorizationCompletePacket : PokeDPacket
    {
        public VarInt PlayerID { get; set; }


        public override VarInt ID => PokeDPacketTypes.AuthorizationComplete;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PlayerID = reader.Read(PlayerID);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(PlayerID);

            return this;
        }
    }
}
