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

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            AuthorizationStatus = (AuthorizationStatus)deserialiser.Read((byte)AuthorizationStatus);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write((byte)AuthorizationStatus);
        }
    }
}