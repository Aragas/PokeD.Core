using System;

namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public class MonsterAbility
    {
        public static MonsterAbility Empty => new MonsterAbility(0, "EMPTY");

        public int ID { get; }
        public string Name { get; }

        public MonsterAbility(int id, string name) { ID = id; Name = name; }

        public override string ToString() => $"{Name}, ID: {ID}";
    }

    public class MonsterAbilities
    {
        public MonsterAbility Ability_0 { get; } = MonsterAbility.Empty;
        public MonsterAbility Ability_1 { get; } = MonsterAbility.Empty;
        public MonsterAbility Ability_2 { get; } = MonsterAbility.Empty;

        public MonsterAbilities(params MonsterAbility[] abilities)
        {
            if (abilities.Length > 0)
                Ability_0 = abilities[0];

            if (abilities.Length > 1)
                Ability_1 = abilities[1];

            if (abilities.Length > 2)
                Ability_2 = abilities[2];

            if (abilities.Length > 3)
                throw new Exception();
        }
        public MonsterAbilities(MonsterAbility ability_0, MonsterAbility ability_1)
        {
            Ability_0 = ability_0;

            Ability_1 = ability_1;
        }

        public override string ToString() => $"Ability1: {Ability_0}; Ability2: {Ability_1}";


        public bool Contains(MonsterAbility ability) => Ability_0 == ability || Ability_1 == ability || Ability_2 == ability;
        public bool Contains(short ability) => Ability_0.ID == ability || Ability_1.ID == ability || Ability_2.ID == ability;
    }
}