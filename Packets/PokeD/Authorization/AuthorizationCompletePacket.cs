using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class AuthorizationCompletePacket : PokeDPacket
    {
        public VarInt PlayerId { get; set; }


        public override VarInt ID => PokeDPacketTypes.AuthorizationComplete;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PlayerId = reader.Read(PlayerId);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(PlayerId);

            return this;
        }
    }
}
