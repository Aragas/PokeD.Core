﻿using Aragas.Network.Attributes;

using PokeD.Core.IO;

namespace PokeD.Core.Packets.P3D.Chat
{
    [Packet((int) P3DPacketTypes.ChatMessagePrivate)]
    public class ChatMessagePrivatePacket : P3DPacket
    {
        public string DestinationPlayerName { get => DataItems[0]; set => DataItems[0] = value; }
        public string Message { get => DataItems[1]; set => DataItems[1] = value; }

        public override void Deserialize(P3DDeserializer deserialiser) { }
        public override void Serialize(P3DSerializer serializer) { }
    }
}
