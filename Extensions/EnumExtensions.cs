using System;
using System.Linq;

using PokeD.Core.Wrappers;

namespace PokeD.Core.Extensions
{
    public static class EnumExtensions
    {
        public static Func<T>[] CreatePacketInstances<T>(this Enum packetType)
        {
            var typeNames = Enum.GetValues(packetType.GetType());
            var packets = new Func<T>[typeNames.Cast<int>().Max() + 1];

            foreach (var packetName in typeNames)
                packets[(int) packetName] = () => AppDomainWrapper.GetTypeFromNameAndAbstract<T>($"{packetName}Packet");

            return packets;
        }
    }
}