using System.Collections.Generic;

namespace PokeD.Core.Data.PokeD.Trainer.Interfaces
{
    public interface IOpponentTeam
    {
        IEnumerable<Monster.Monster> Team { get; }

        Monster.Monster Monster_1 { get; }
        Monster.Monster Monster_2 { get; }
        Monster.Monster Monster_3 { get; }
        Monster.Monster Monster_4 { get; }
        Monster.Monster Monster_5 { get; }
        Monster.Monster Monster_6 { get; }
    }
}