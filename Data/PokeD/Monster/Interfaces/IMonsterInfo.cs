using PokeD.Core.Data.PokeD.Monster.Data;

namespace PokeD.Core.Data.PokeD.Monster.Interfaces
{
    public interface IMonsterInfo
    {
        short Species { get; }
        string DisplayName { get; }
        MonsterCatchInfo CatchInfo { get; }

        byte Level { get; }
        int Experience { get; }
        byte Friendship { get; }

        short CurrentHP { get; }
        short StatusEffect { get; }
        MonsterGender Gender { get; }
        MonsterAbility Ability { get; }
        bool IsShiny { get; }

        MonsterStats Stats { get; }

        int EggSteps { get; }

        MonsterMoves Moves { get; }

        short HeldItem { get; }
    }
}