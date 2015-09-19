namespace PokeD.Core.Packets
{
    public enum SCONPacketTypes
    {
        AuthorizationRequest    = 0x00,
        AuthorizationResponse   = 0x01,
        EncryptionRequest       = 0x02,
        EncryptionResponse      = 0x03,
        AuthorizationComplete   = 0x04,
        AuthorizationDisconnect = 0x05,
        ExecuteCommand          = 0x06,
        PlayerListRequest       = 0x07,
        PlayerListResponse      = 0x08,
    }
}
