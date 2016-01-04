namespace PokeD.Core.Data.PokeD.Monster
{
    public interface IMonsterBaseInfo
    {
        short ID { get; }
        string DisplayName { get; }
        short TrainerID { get; }

        byte Level { get; }

        MonsterGender Gender { get; }
        bool IsShiny { get; }
    }
}