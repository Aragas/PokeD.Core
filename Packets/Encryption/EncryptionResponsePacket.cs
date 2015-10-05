﻿using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Encryption
{
    public class EncryptionResponsePacket : P3DPacket
    {
        public byte[] SharedSecret { get; set; }
        public byte[] VerificationToken { get; set; }

        public override VarInt ID => (int) GamePacketTypes.EncryptionResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            var ssLength = reader.ReadVarInt();
            SharedSecret = reader.ReadByteArray(ssLength);
            var vtLength = reader.ReadVarInt();
            VerificationToken = reader.ReadByteArray(vtLength);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(new VarInt(SharedSecret.Length));
            stream.Write(SharedSecret);
            stream.Write(new VarInt(VerificationToken.Length));
            stream.Write(VerificationToken);

            return this;
        }
    }
}
