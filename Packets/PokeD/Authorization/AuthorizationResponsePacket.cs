using System;

using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    [Flags]
    public enum AuthorizationStatus { EncryprionEnabled = 1 }

    public class AuthorizationResponsePacket : PokeDPacket
    {
        public AuthorizationStatus AuthorizationStatus { get; set; }


        public override VarInt ID => PokeDPacketTypes.AuthorizationResponse;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            AuthorizationStatus = (AuthorizationStatus) reader.Read((byte) AuthorizationStatus);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write((byte) AuthorizationStatus);

            return this;
        }
    }
}