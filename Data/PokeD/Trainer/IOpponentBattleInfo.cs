using Aragas.Core.Data;
using PokeD.Core.Data.PokeD.Monster;

namespace PokeD.Core.Data.PokeD.Trainer
{
    public interface IOpponentBattleInfo
    {
        VarInt EntityID { get; }
        short TrainerSprite { get; }

        IMonsterBattleInfo MainMonster { get; }
    }
}