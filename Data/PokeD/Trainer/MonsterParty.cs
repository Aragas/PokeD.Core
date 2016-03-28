using System.Collections.Generic;

using PokeD.Core.Data.PokeD.Trainer.Interfaces;

namespace PokeD.Core.Data.PokeD.Trainer
{
    public class MonsterParty : IOpponentTeam
    {
        public IEnumerable<Monster.Monster> Team => new List<Monster.Monster> { Monster_1, Monster_2, Monster_3, Monster_4, Monster_5, Monster_6 };

        public Monster.Monster Monster_1 { get; set; }
        public Monster.Monster Monster_2 { get; set; }
        public Monster.Monster Monster_3 { get; set; }
        public Monster.Monster Monster_4 { get; set; }
        public Monster.Monster Monster_5 { get; set; }
        public Monster.Monster Monster_6 { get; set; }
    }
}