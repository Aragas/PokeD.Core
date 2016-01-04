namespace PokeD.Core.Data.PokeD.Monster
{
    public enum MonsterStatType
    {
        HP,
        Attack,
        Defense,
        SpecialAttack,
        SpecialDefense,
        Speed
    }
    public class MonsterStats
    {
        public short HP { get; }
        public short Attack { get; }
        public short Defense { get; }
        public short SpecialAttack { get; }
        public short SpecialDefense { get; }
        public short Speed { get; }

        public short GetStat(MonsterStatType statType)
        {
            switch (statType)
            {
                case MonsterStatType.HP:
                    return HP;
                case MonsterStatType.Attack:
                    return Attack;
                case MonsterStatType.Defense:
                    return Defense;
                case MonsterStatType.SpecialAttack:
                    return SpecialAttack;
                case MonsterStatType.SpecialDefense:
                    return SpecialDefense;
                case MonsterStatType.Speed:
                    return Speed;
            }

            return 0;
        }

        public MonsterStats(short hp, short attack, short defense, short specialAttack, short specialDefense, short speed)
        {
            HP = hp;
            Attack = attack;
            Defense = defense;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
        }
    }
}