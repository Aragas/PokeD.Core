using System;
using System.Collections.Generic;
using System.Reflection;

using Aragas.Network.Packets;

using PCLExt.AppDomain;

namespace PokeD.Core.Packets.VBA
{
    public enum VBAPacketTypes
    {
        Connect     = 0x01,

        E1          = 0xE1,
        E4          = 0xE4,

        Disconnect  = 0xF1,
    }

    public static class VBAPacketResponses
    {
        private static readonly Dictionary<int, Func<VBAPacket>> Packets = Packet.CreateIDList<VBAPacket>(typeof(VBAPacketTypes), new Assembly[] { AppDomain.GetAssembly(typeof(VBAPacketResponses)) });

        public static bool TryGetPacketFunc(int key, out Func<VBAPacket> func) => Packets.TryGetValue(key, out func);
    }
}
