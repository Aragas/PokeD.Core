﻿using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerDatabaseListResponsePacket : SCONPacket
    {
        public PlayerDatabase[] PlayerDatabases { get; set; } = new PlayerDatabase[0];


        public override VarInt ID => SCONPacketTypes.PlayerDatabaseListResponse;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PlayerDatabases = reader.Read(PlayerDatabases);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(PlayerDatabases);

            return this;
        }
    }
}
