﻿using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Authorization
{
    public class AuthorizationRequestPacket : PokeDPacket
    {
        public string Name { get; set; } = string.Empty;


        public override VarInt ID => PokeDPacketTypes.AuthorizationRequest;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Name = reader.Read(Name);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(Name);

            return this;
        }
    }
}
