﻿using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.PokeD.Structs;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleItemPacket : PokeDPacket
    {
        private MetaItem Info { get; set; }

        public short Monster { get { return Info.Monster; } set { Info.Monster = value; } }
        public short Item { get { return Info.Item; } set { Info.Item = value; } }


        public override VarInt ID => (int) PokeDPacketTypes.BattleItem;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Info = reader.Read(Info);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(Info);

            return this;
        }
    }
}