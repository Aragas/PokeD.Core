﻿using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogListResponsePacket : SCONPacket
    {
        public Log[] CrashLogs { get; set; } = new Log[0];


        public override VarInt ID => SCONPacketTypes.CrashLogListResponse;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            CrashLogs = deserialiser.Read(CrashLogs);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(CrashLogs);
        }
    }
}
