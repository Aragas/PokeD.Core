using PokeD.Core.Packets.SCON;
using PokeD.Core.Packets.SCON.Authorization;
using PokeD.Core.Packets.SCON.Status;

namespace PokeD.Core.Packets
{
    public static class SCONResponse
    {
        public delegate Packet CreatePacketInstance();

        public static readonly CreatePacketInstance[] Packets =
        {
            () => new AuthorizationRequestPacket(),     // 0x00
            () => new AuthorizationResponsePacket(),    // 0x01

            () => new EncryptionRequestPacket(),        // 0x02
            () => new EncryptionResponsePacket(),       // 0x03

            () => new AuthorizationCompletePacket(),    // 0x04
            () => new AuthorizationDisconnectPacket(),  // 0x05

            () => new ExecuteCommandPacket(),           // 0x06

            () => new PlayerListRequestPacket(),        // 0x07
            () => new PlayerListResponsePacket(),       // 0x08

            null, // 0x09
            null, // 0x0A
            null, // 0x0B
            null, // 0x0C
            null, // 0x0D
            null, // 0x0E
            null, // 0x0F
            null, // 0x10
            null, // 0x11
            null, // 0x12
            null, // 0x13
            null, // 0x14
            null, // 0x15
            null, // 0x16
            null, // 0x17
            null, // 0x18
            null, // 0x19
            null, // 0x1A
            null, // 0x1B
            null, // 0x1C
            null, // 0x1D
            null, // 0x1E
            null  // 0x1F
        };
    }
}
