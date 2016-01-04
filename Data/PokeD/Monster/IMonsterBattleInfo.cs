namespace PokeD.Core.Data.PokeD.Monster
{
    public interface IMonsterBattleInfo
    {
        short ID { get; }
        string DisplayName { get; }

        byte Level { get; }
        short CurrentHP { get; }
        short StatusEffect { get; }

        MonsterGender Gender { get; }
        bool IsShiny { get; }
    }
}