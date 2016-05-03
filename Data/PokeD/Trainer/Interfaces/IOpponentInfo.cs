using PokeD.Core.Data.PokeD.Trainer.Data;

namespace PokeD.Core.Data.PokeD.Trainer.Interfaces
{
    public interface IOpponentInfo
    {
        int EntityID { get; }
        short TrainerSprite { get; }

        string Name { get; }
        short TrainerID { get; }

        TrainerGender Gender { get; }
    }
}