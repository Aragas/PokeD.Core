﻿using Aragas.Core.Data;
using PokeD.Core.Data.Structs;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogListResponsePacket : ProtobufPacket
    {
        public LogList LogList { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.LogListResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            LogList = LogList.FromReader(reader);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            LogList.ToStream(stream);

            return this;
        }
    }
}
