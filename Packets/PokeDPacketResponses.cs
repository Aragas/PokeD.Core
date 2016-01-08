using System;

using Aragas.Core.Extensions;
using Aragas.Core.Wrappers;

namespace PokeD.Core.Packets
{
    public enum PokeDPacketTypes
    {
        AuthorizationRequest    = 0xA1,
        AuthorizationResponse   = 0xA2,
        AuthorizationDisconnect = 0xA3,
        AuthorizationComplete   = 0xA4,
        EncryptionRequest       = 0xA5,
        EncryptionResponse      = 0xA6,


        BattleRequest           = 0xB0,
        BattleCancelled         = 0xB1,
        BattleOffer             = 0xB2,
        BattleAccept            = 0xB3,
        
        BattleAttack            = 0xB4,
        BattleItem              = 0xB5,
        BattleSwitch            = 0xB6,
        BattleFlee              = 0xB7,
        
        BattleState             = 0xB8,


        ChatGlobalMessage       = 0xC0,
        ChatPrivateMessage      = 0xC1,
        ChatServerMessage       = 0xC2,


        Position                = 0xD0,
        TrainerInfo             = 0xD1,


        TradeOffer              = 0xE0,
        TradeAccept             = 0xE1,
        TradeRefuse             = 0xE2,

        Disconnect              = 0xFF,
    }

    public static class PokeDPacketResponses
    {
        public static readonly Func<PokeDPacket>[] Packets;

        static PokeDPacketResponses()
        {
            new PokeDPacketTypes().CreatePacketInstancesOut(out Packets, AppDomainWrapper.GetAssembly(typeof(PokeDPacketResponses)));
        }
    }
}
