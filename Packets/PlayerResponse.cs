using System;
using System.Linq;

using PokeD.Core.Wrappers;

namespace PokeD.Core.Packets
{
    public static class PlayerResponse
    {
        public delegate P3DPacket CreatePacketInstance();

        public static readonly CreatePacketInstance[] Packets;

        static PlayerResponse()
        {
            var typeNames = Enum.GetValues(typeof (PlayerPacketTypes));
            Packets = new CreatePacketInstance[typeNames.Cast<int>().Max() + 1];

            foreach (PlayerPacketTypes packetName in typeNames)
            {
                var name = $"{packetName}Packet";

                var packet = AppDomainWrapper.GetTypeFromNameAndAbstract<P3DPacket>(name);
                Packets[(int) packetName] = () => packet;
            }
        }
    }
}
