﻿using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Encryption
{
    public class EncryptionRequestPacket : P3DPacket
    {
        public byte[] PublicKey { get; set; }
        public byte[] VerificationToken { get; set; }

        public override int ID => (int) PlayerPacketTypes.EncryptionRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            var pkLength = reader.ReadVarInt();
            PublicKey = reader.ReadByteArray(pkLength);
            var vtLength = reader.ReadVarInt();
            VerificationToken = reader.ReadByteArray(vtLength);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteVarInt(PublicKey.Length);
            stream.WriteByteArray(PublicKey);
            stream.WriteVarInt(VerificationToken.Length);
            stream.WriteByteArray(VerificationToken);

            return this;
        }
    }
}