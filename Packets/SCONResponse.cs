using PokeD.Core.Packets.SCON;
using PokeD.Core.Packets.SCON.Authorization;
using PokeD.Core.Packets.SCON.Chat;
using PokeD.Core.Packets.SCON.Logs;
using PokeD.Core.Packets.SCON.Status;

namespace PokeD.Core.Packets
{
    public static class SCONResponse
    {
        public delegate ProtobufPacket CreatePacketInstance();

        public static readonly CreatePacketInstance[] Packets =
        {
            () => new AuthorizationRequestPacket(),     // 0x00
            () => new AuthorizationResponsePacket(),    // 0x01

            () => new EncryptionRequestPacket(),        // 0x02
            () => new EncryptionResponsePacket(),       // 0x03

            () => new AuthorizationPasswordPacket(),    // 0x04
            () => new AuthorizationCompletePacket(),    // 0x05
            () => new AuthorizationDisconnectPacket(),  // 0x06

            () => new ExecuteCommandPacket(),           // 0x07

            () => new PlayerListRequestPacket(),        // 0x08
            () => new PlayerListResponsePacket(),       // 0x09

            () => new StartChatReceivingPacket(),       // 0x0A
            () => new StopChatReceivingPacket(),        // 0x0B
            () => new ChatMessagePacket(),              // 0x0C

            () => new PlayerLocationRequestPacket(),    // 0x0D
            () => new PlayerLocationResponsePacket(),   // 0x0E

            () => new LogListRequestPacket(),           // 0x0F
            () => new LogListResponsePacket(),          // 0x10

            () => new LogFileRequestPacket(),           // 0x11
            () => new LogFileResponsePacket(),          // 0x12

            () => new CrashLogListRequestPacket(),      // 0x13
            () => new CrashLogListResponsePacket(),     // 0x14

            () => new CrashLogFileRequestPacket(),      // 0x15
            () => new CrashLogFileResponsePacket(),     // 0x16

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
