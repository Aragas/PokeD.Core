using PokeD.Core.Data.PokeD.Trainer.Data;

namespace PokeD.Core.Data.PokeD.Trainer.Interfaces
{
    public interface IOpponentInfo
    {
        int EntityId { get; }
        short TrainerSprite { get; }

        string Name { get; }
        short TrainerId { get; }

        TrainerGender Gender { get; }
    }
}