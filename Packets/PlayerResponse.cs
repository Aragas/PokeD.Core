using System;
using System.Collections.Generic;

using PokeD.Core.Wrappers;

namespace PokeD.Core.Packets
{
    public static class PlayerResponse
    {
        public delegate P3DPacket CreatePacketInstance();

        public static readonly CreatePacketInstance[] Packets;

        static PlayerResponse()
        {
            var list = new List<CreatePacketInstance>();

            foreach (SCONPacketTypes packetName in Enum.GetValues(typeof(PlayerPacketTypes)))
            {
                var name = $"{packetName}Packet";

                var packet = AppDomainWrapper.GetTypeFromNameAndAbstract<P3DPacket>(name);
                list.Insert((int) packetName, () => packet);
            }

            Packets = list.ToArray();
        }
    }
}
