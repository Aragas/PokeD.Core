using Aragas.Core.Data;

using PokeD.Core.Data.PokeD.Trainer.Data;

namespace PokeD.Core.Data.PokeD.Trainer.Interfaces
{
    public interface IOpponentInfo
    {
        VarInt EntityID { get; }
        short TrainerSprite { get; }

        string Name { get; }
        short TrainerID { get; }

        TrainerGender Gender { get; }
    }
}