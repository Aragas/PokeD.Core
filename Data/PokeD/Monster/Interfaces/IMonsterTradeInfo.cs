using PokeD.Core.Data.PokeD.Monster.Data;

namespace PokeD.Core.Data.PokeD.Monster.Interfaces
{
    public interface IMonsterTradeInfo
    {
        short ID { get; }
        string DisplayName { get; }
        MonsterCatchInfo CatchInfo { get; }

        byte Level { get; }
        int Experience { get; }

        MonsterGender Gender { get; }
        bool IsShiny { get; }

        short HeldItem { get; }
    }
}