using System;

using Aragas.Network.IO;

namespace PokeD.Core.Packets.SCON.Authorization
{
    [Flags]
    public enum AuthorizationStatus
    {
        EncryprionEnabled = 1
    }

    public class AuthorizationResponsePacket : SCONPacket
    {
        public AuthorizationStatus AuthorizationStatus { get; set; }


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            AuthorizationStatus = (AuthorizationStatus) deserialiser.Read((byte) AuthorizationStatus);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write((byte) AuthorizationStatus);
        }
    }
}