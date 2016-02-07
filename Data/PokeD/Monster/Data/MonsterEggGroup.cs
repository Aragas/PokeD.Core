using System;

namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public class MonsterEggGroup
    {
        public static MonsterEggGroup Empty => new MonsterEggGroup(0, "EMPTY");

        public int ID { get; }
        public string Name { get; }

        public MonsterEggGroup(int id, string name) { ID = id; Name = name; }

        public override string ToString() => $"{Name}, ID: {ID}";
    }

    public class MonsterEggGroups
    {
        public MonsterEggGroup Type_0 { get; } = MonsterEggGroup.Empty;
        public MonsterEggGroup Type_1 { get; } = MonsterEggGroup.Empty;

        public MonsterEggGroups(params MonsterEggGroup[] eggGroups)
        {
            if (eggGroups.Length > 0)
                Type_0 = eggGroups[0];

            if (eggGroups.Length > 1)
                Type_1 = eggGroups[1];

            if (eggGroups.Length > 2)
                throw new Exception();
        }
        public MonsterEggGroups(MonsterEggGroup eggGroup_0, MonsterEggGroup eggGroup_1)
        {
            Type_0 = eggGroup_0;

            Type_1 = eggGroup_1;
        }

        public override string ToString() => $"Type1: {Type_0}; Type2: {Type_1}";


        public bool Contains(MonsterEggGroup eggGroup) => Type_0 == eggGroup || Type_1 == eggGroup;
        public bool Contains(short eggGroup) => Type_0.ID == eggGroup || Type_1.ID == eggGroup;
    }
}