namespace PokeD.Core.Data.PokeD.Monster
{
    public interface IMonsterInfo
    {
        short ID { get; }
        string DisplayName { get; }
        short TrainerID { get; }

        byte Level { get; }
        int Experience { get; }
        byte Friendship { get; }

        short CurrentHP { get; }
        short StatusEffect { get; }
        MonsterGender Gender { get; }
        short Ability { get; }
        bool IsShiny { get; }

        //MonsterStats BaseStats { get; }
        //MonsterStats EV { get; }
        //MonsterStats IV { get; }
        MonsterStats Stats { get; }

        int EggSteps { get; }

        MonsterMoves Moves { get; }

        short HeldItem { get; }
    }
}