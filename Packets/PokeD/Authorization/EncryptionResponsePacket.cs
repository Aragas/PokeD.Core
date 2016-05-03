using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class EncryptionResponsePacket : PokeDPacket
    {
        public byte[] SharedSecret { get; set; } = new byte[0];
        public byte[] VerificationToken { get; set; } = new byte[0];


        public override VarInt ID => PokeDPacketTypes.EncryptionResponse;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            SharedSecret = reader.Read(SharedSecret);
            VerificationToken = reader.Read(VerificationToken);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(SharedSecret);
            stream.Write(VerificationToken);

            return this;
        }
    }
}
