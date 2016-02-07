using System;

namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public class MonsterType
    {
        public static MonsterType Empty => new MonsterType(0, "EMPTY");

        public int ID { get; }
        public string Name { get; }

        public MonsterType(int id, string name) { ID = id; Name = name; }

        public override string ToString() => $"{Name}, ID: {ID}";
    }
    public class MonsterTypes
    {
        public MonsterType Type_0 { get; } = MonsterType.Empty;
        public MonsterType Type_1 { get; } = MonsterType.Empty;

        public MonsterTypes(params MonsterType[] types)
        {
            if (types.Length > 0)
                Type_0 = types[0];

            if (types.Length > 1)
                Type_1 = types[1];

            if (types.Length > 2)
                throw new Exception();
        }

        public MonsterTypes(MonsterType type_0, MonsterType type_1)
        {
            Type_0 = type_0;

            Type_1 = type_1;
        }

        public override string ToString() => $"Type1: {Type_0}; Type2: {Type_1}";


        public bool Contains(MonsterType type) => Type_0 == type || Type_1 == type;
        public bool Contains(short type) => Type_0.ID == type || Type_1.ID == type;
    }
}