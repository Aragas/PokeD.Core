﻿using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleFleePacket : PokeDPacket
    {
        public override VarInt ID => (int) PokeDPacketTypes.BattleFlee;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            return this;
        }
    }
}
