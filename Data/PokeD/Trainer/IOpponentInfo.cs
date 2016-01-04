using Aragas.Core.Data;

namespace PokeD.Core.Data.PokeD.Trainer
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