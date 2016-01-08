namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public enum EggGroups
    {
        None            = 0,
        Monster         = 1,
        Water1          = 2,
        Bug             = 3,
        Flying          = 4,
        Ground          = 5,
        Fairy           = 6,
        Plant           = 7,
        HumanLike       = 8,
        Water3          = 9,
        Mineral         = 10,
        Indeterminate   = 11,
        Water2          = 12,
        Ditto           = 13,
        Dragon          = 14,
        Undiscovered    = 15
    }

    public class MonsterEggGroup
    {
        public EggGroups EggGroup_0 { get; } = EggGroups.None;
        public EggGroups EggGroup_1 { get; } = EggGroups.None;


        public MonsterEggGroup(params EggGroups[] eggGroups)
        {
            if (eggGroups.Length > 0)
                EggGroup_0 = eggGroups[0];

            if (eggGroups.Length > 1)
                EggGroup_1 = eggGroups[1];
        }
        public MonsterEggGroup(EggGroups eggGroup_0, EggGroups eggGroup_1)
        {
            EggGroup_0 = eggGroup_0;
            EggGroup_1 = eggGroup_1;
        }

        public override string ToString() => $"EggGroup1: {EggGroup_0}, EggGroup2: {EggGroup_1}";
    }
}