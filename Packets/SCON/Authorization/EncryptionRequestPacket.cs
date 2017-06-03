﻿using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    public class EncryptionRequestPacket : SCONPacket
    {
        public byte[] PublicKey { get; set; } = new byte[0];
        public byte[] VerificationToken { get; set; } = new byte[0];


        public override VarInt ID => SCONPacketTypes.EncryptionRequest;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            PublicKey = deserialiser.Read(PublicKey);
            VerificationToken = deserialiser.Read(VerificationToken);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(PublicKey);
            serializer.Write(VerificationToken);
        }
    }
}
