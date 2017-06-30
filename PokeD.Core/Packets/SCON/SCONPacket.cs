﻿using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON
{
    public abstract class SCONPacket : PacketWithEnumName<VarInt, ProtobufSerializer, ProtobufDeserialiser>
    {

    }
}
