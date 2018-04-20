﻿using Aragas.Network.IO;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class AuthorizationPasswordPacket : SCONPacket
    {
        public string PasswordHash { get; set; } = string.Empty;


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            PasswordHash = deserialiser.Read(PasswordHash);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(PasswordHash);
        }
    }
}
