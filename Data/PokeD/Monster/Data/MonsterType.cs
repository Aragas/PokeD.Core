namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public enum Types
    {
        None        = 0,
        Normal      = 1,
        Fighting    = 2,
        Flying      = 3,
        Poison      = 4,
        Ground      = 5,
        Rock        = 6,
        Bug         = 7,
        Ghost       = 8,
        Steel       = 9,
        Fire        = 10,
        Water       = 11,
        Grass       = 12,
        Electric    = 13,
        Psychic     = 14,
        Ice         = 15,
        Dragon      = 16,
        Dark        = 17,
        Fairy       = 18
    }
    public class MonsterType
    {
        public Types Type_0 { get; } = Types.None;
        public Types Type_1 { get; } = Types.None;

        public MonsterType(params Types[] types)
        {
            if(types.Length > 0)
                Type_0 = types[0];

            if(types.Length > 1)
                Type_1 = types[1];
        }
        public MonsterType(Types type_0, Types type_1)
        {
            Type_0 = type_0;
            Type_1 = type_1;
        }

        public override string ToString() => $"Type1: {Type_0}, Type2: {Type_1}";
    }
}