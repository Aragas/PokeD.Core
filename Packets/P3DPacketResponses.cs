using System;

using Aragas.Core.Extensions;
using Aragas.Core.Wrappers;

namespace PokeD.Core.Packets
{
    public enum P3DPacketTypes
    {
        GameData                    = 0x00,
        PlayData                    = 0x01,
        ChatMessagePrivate          = 0x02,
        ChatMessageGlobal           = 0x03,
        Kicked                      = 0x04,

        ID                          = 0x07,
        CreatePlayer                = 0x08,
        DestroyPlayer               = 0x09,
        ServerClose                 = 0x0A,
        ServerMessage               = 0x0B,
        WorldData                   = 0x0C,
        Ping                        = 0x0D,
        GameStateMessage            = 0x0E,

        TradeRequest                = 0x1E,
        TradeJoin                   = 0x1F,
        TradeQuit                   = 0x20,

        TradeOffer                  = 0x21,
        TradeStart                  = 0x22,

        BattleRequest               = 0x32,
        BattleJoin                  = 0x33,
        BattleQuit                  = 0x34,

        BattleOffer                 = 0x35,
        BattleStart                 = 0x36,

        BattleClientData            = 0x37,
        BattleHostData              = 0x38,
        BattlePokemonData           = 0x39,

        ServerInfoData              = 0x62,
        ServerDataRequest           = 0x63
    }

    public static class P3DPacketResponses
    {
        public static readonly Func<P3DPacket>[] Packets;

        static P3DPacketResponses()
        {
            new P3DPacketTypes().CreatePacketInstancesOut(out Packets, AppDomainWrapper.GetAssembly(typeof(P3DPacketResponses)));
        }
    }
}
