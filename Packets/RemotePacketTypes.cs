namespace PokeD.Core.Packets
{
    public enum RemotePacketTypes
    {
        AuthorizationRequestPacket      = 0x00,
        AuthorizationResponsePacket     = 0x01,
        EncryptionRequestPacket         = 0x02,
        EncryptionResponsePacket        = 0x03,
        CompressionRequestPacket        = 0x04,
        CompressionResponsePacket       = 0x05,
        AuthorizationCompletePacket     = 0x06,
        AuthorizationDisconnectPacket   = 0x07,
    }
}
