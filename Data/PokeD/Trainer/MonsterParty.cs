using PokeD.Core.Data.PokeD.Trainer.Interfaces;

namespace PokeD.Core.Data.PokeD.Trainer
{
    public class MonsterParty : IOpponentTeam
    {
        public Monster.Monster Monster_1 { get; set; }
        public Monster.Monster Monster_2 { get; set; }
        public Monster.Monster Monster_3 { get; set; }
        public Monster.Monster Monster_4 { get; set; }
        public Monster.Monster Monster_5 { get; set; }
        public Monster.Monster Monster_6 { get; set; }
    }
}