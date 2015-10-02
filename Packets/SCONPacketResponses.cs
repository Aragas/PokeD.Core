using System;

using PokeD.Core.Extensions;

namespace PokeD.Core.Packets
{
    public enum SCONPacketTypes
    {
        AuthorizationRequest = 0x00,
        AuthorizationResponse = 0x01,

        EncryptionRequest = 0x02,
        EncryptionResponse = 0x03,

        AuthorizationPassword = 0x04,
        AuthorizationComplete = 0x05,
        AuthorizationDisconnect = 0x06,

        ExecuteCommand = 0x07,

        BanListRequest = 0x08,
        BanListResponse = 0x09,

        StartChatReceiving = 0x0A,
        StopChatReceiving = 0x0B,
        ChatMessage = 0x0C,

        PlayerInfoListRequest = 0x0D,
        PlayerInfoListResponse = 0x0E,

        LogListRequest = 0x0F,
        LogListResponse = 0x10,

        LogFileRequest = 0x11,
        LogFileResponse = 0x12,

        CrashLogListRequest = 0x13,
        CrashLogListResponse = 0x14,

        CrashLogFileRequest = 0x15,
        CrashLogFileResponse = 0x16,

        BanPlayer = 0x17,
        UnBanPlayer = 0x18,

        PlayerDatabaseListRequest = 0x19,
        PlayerDatabaseListResponse = 0x1A
    }

    public static class SCONPacketResponses
    {
        public static readonly Func<ProtobufPacket>[] Packets;

        static SCONPacketResponses()
        {
            Packets = new SCONPacketTypes().CreatePacketInstances<ProtobufPacket>();
        }
    }
}
