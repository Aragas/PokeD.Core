﻿using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Remote.Authorization
{
    public class CompressionResponsePacket : IPacket
    {
        public uint Threshold { get; set; }

        public override int ID => (int) RemotePacketTypes.CompressionResponsePacket;

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            Threshold = reader.ReadUInt();

            return this;
        }

        public override IPacket WritePacket(IPokeStream stream)
        {
            stream.WriteUInt(Threshold);

            return this;
        }
    }
}