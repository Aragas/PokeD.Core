using PokeD.Core.Data.PokeD.Monster.Data;

namespace PokeD.Core.Data.PokeD.Monster.Interfaces
{
    public interface IMonsterBattleInfo
    {
        short Species { get; }
        string DisplayName { get; }

        byte Level { get; }
        short CurrentHP { get; }
        short StatusEffect { get; }

        MonsterGender Gender { get; }
        bool IsShiny { get; }
    }
}