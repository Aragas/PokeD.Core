using PokeD.Core.Data.PokeD.Monster.Data;

namespace PokeD.Core.Data.PokeD.Monster.Interfaces
{
    public interface IMonsterBaseInfo
    {
        short ID { get; }
        string DisplayName { get; }
        MonsterCatchInfo CatchInfo { get; }
            
        byte Level { get; }

        MonsterGender Gender { get; }
        bool IsShiny { get; }
    }
}