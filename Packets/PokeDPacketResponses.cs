using System;

using Aragas.Core.Extensions;
using Aragas.Core.Wrappers;

namespace PokeD.Core.Packets
{
    public enum PokeDPacketTypes
    {
        Position                = 0x00,
        TrainerInfo             = 0x01,

        BattleRequest           = 0xB0,
        BattleCancelled         = 0xB8,
        BattleOffer             = 0xB1,
        BattleAccept            = 0xB2,
        
        BattleAttack            = 0xB3,
        BattleItem              = 0xB4,
        BattleSwitch            = 0xB5,
        BattleFlee              = 0xB6,

        BattleState             = 0xB7,

        ChatGlobalMessage       = 0xC0,
        ChatPrivateMessage      = 0xC1,
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
