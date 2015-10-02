using System;

using PokeD.Core.Extensions;

namespace PokeD.Core.Packets
{
    public enum GamePacketTypes
    {
        GameData = 0x00,
        PlayData = 0x01,
        ChatMessagePrivate = 0x02,
        ChatMessageGlobal = 0x03,
        Kicked = 0x04,

        ID = 0x07,
        CreatePlayer = 0x08,
        DestroyPlayer = 0x09,
        ServerClose = 0x0A,
        ServerMessage = 0x0B,
        WorldData = 0x0C,
        Ping = 0x0D,
        GameStateMessage = 0x0E,

        TradeRequest = 0x1E,
        TradeJoin = 0x1F,
        TradeQuit = 0x20,

        TradeOffer = 0x21,
        TradeStart = 0x22,

        BattleRequest = 0x32,
        BattleJoin = 0x33,
        BattleQuit = 0x34,

        BattleOffer = 0x35,
        BattleStart = 0x36,

        BattleClientData = 0x37,
        BattleHostData = 0x38,
        BattlePokemonData = 0x39,

        EncryptionRequest = 0x50,
        EncryptionResponse = 0x51,
        JoiningGameRequest = 0x52,
        JoiningGameResponse = 0x53,

        ServerInfoData = 0x62,
        ServerDataRequest = 0x63,
    }

    public static class GamePacketResponses
    {
        public static readonly Func<P3DPacket>[] Packets;

        static GamePacketResponses()
        {
            Packets = new GamePacketTypes().CreatePacketInstances<P3DPacket>();
        }
    }
}
