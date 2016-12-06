using PokeD.Core.Data.PokeD.Monster.Interfaces;

namespace PokeD.Core.Data.PokeD.Trainer.Interfaces
{
    public interface IOpponentBattleInfo
    {
        int EntityId { get; }
        short TrainerSprite { get; }

        IMonsterBattleInfo MainMonster { get; }
    }
}