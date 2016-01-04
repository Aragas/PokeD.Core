using System;

using Aragas.Core.Extensions;
using Aragas.Core.Wrappers;

namespace PokeD.Core.Packets
{
    public enum PokeDPacketTypes
    {

    }

    public static class PokeDPacketResponses
    {
        public static readonly Func<PokeDPacket>[] Packets;

        static PokeDPacketResponses()
        {
            new PokeDPacketTypes().CreatePacketInstancesOut(out Packets, AppDomainWrapper.GetAssembly(typeof(PokeDPacketResponses)));
        }
    }
}
