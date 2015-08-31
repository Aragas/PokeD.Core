namespace PokeD.Core.Packets
{
    public enum PlayerPacketTypes
    {
        Unknown             =-0x01,
        GameData            = 0x00,
        PlayData            = 0x01,
        PrivateMessage      = 0x02,
        ChatMessage         = 0x03,
        Kicked              = 0x04,
        ID                  = 0x07,
        CreatePlayer        = 0x08,
        DestroyPlayer       = 0x09,
        ServerClose         = 0x0A,
        ServerMessage       = 0x0B,
        WorldData           = 0x0C,
        Ping                = 0x0D,
        GameStateMessage    = 0x0E,

        TradeRequest        = 0x1E,
        TradeJoin           = 0x1F,
        TradeQuit           = 0x20,

        TradeOffer          = 0x21,
        TradeStart          = 0x22,

        BattleRequest       = 0x32,
        BattleJoin          = 0x33,
        BattleQuit          = 0x34,

        BattleOffer         = 0x35,
        BattleStart         = 0x36,

        BattleClientData    = 0x37,
        BattleHostData      = 0x38,
        BattlePokemonData   = 0x39,

        ServerInfoData      = 0x62,
        ServerDataRequest   = 0x63,
    }
}
