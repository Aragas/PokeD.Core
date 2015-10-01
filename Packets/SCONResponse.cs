using System;
using System.Collections.Generic;

using PokeD.Core.Wrappers;

namespace PokeD.Core.Packets
{
    public static class SCONResponse
    {
        public delegate ProtobufPacket CreatePacketInstance();

        public static readonly CreatePacketInstance[] Packets;

        static SCONResponse()
        {
            var list = new List<CreatePacketInstance>();
            
            foreach (SCONPacketTypes packetName in Enum.GetValues(typeof(SCONPacketTypes)))
            {
                var name = $"{packetName}Packet";

                var packet = AppDomainWrapper.GetTypeFromNameAndAbstract<ProtobufPacket>(name);
                list.Insert((int) packetName, () => packet);
            }

            Packets = list.ToArray();
        }
    }
}
