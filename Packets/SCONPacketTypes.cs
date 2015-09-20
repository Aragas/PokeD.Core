namespace PokeD.Core.Packets
{
    public enum SCONPacketTypes
    {
        AuthorizationRequest    = 0x00,
        AuthorizationResponse   = 0x01,

        EncryptionRequest       = 0x02,
        EncryptionResponse      = 0x03,

        AuthorizationPassword   = 0x04,
        AuthorizationComplete   = 0x05,
        AuthorizationDisconnect = 0x06,

        ExecuteCommand          = 0x07,

        PlayerListRequest       = 0x08,
        PlayerListResponse      = 0x09,

        StartChatReceiving      = 0x0A,
        StopChatReceiving       = 0x0B,
        ChatMessage             = 0x0C,

        PlayerLocationRequest   = 0x0D,
        PlayerLocationResponse  = 0x0E,

        LogListRequest          = 0x0F,
        LogListResponse         = 0x10,

        LogFileRequest          = 0x11,
        LogFileResponse         = 0x12,

        CrashLogListRequest     = 0x13,
        CrashLogListResponse    = 0x14,

        CrashLogFileRequest     = 0x15,
        CrashLogFileResponse    = 0x16,
    }
}
