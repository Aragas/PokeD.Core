﻿using Aragas.Network.IO;

namespace PokeD.Core.Packets.SCON.Chat
{
    public class ChatReceivePacket : SCONPacket
    {
        public bool Enabled { get; set; }


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            Enabled = deserialiser.Read(Enabled);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(Enabled);
        }
    }
}
