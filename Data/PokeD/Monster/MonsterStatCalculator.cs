using System;

namespace PokeD.Core.Data.PokeD.Monster
{
    public static class MonsterStatCalculator
    {
        public static MonsterStats CalculateStats(Monster monster)
        {
            var hp = CalculateStat(monster, MonsterStatType.HP);
            var attack = CalculateStat(monster, MonsterStatType.Attack);
            var defence = CalculateStat(monster, MonsterStatType.Defense);
            var spAttack = CalculateStat(monster, MonsterStatType.SpecialAttack);
            var spDefence = CalculateStat(monster, MonsterStatType.SpecialDefense);
            var speed = CalculateStat(monster, MonsterStatType.Speed);

            return new MonsterStats(hp, attack, defence, spAttack, spDefence, speed);
        }

        public static short CalculateStat(Monster monster, MonsterStatType statType)
        {
            if (statType == MonsterStatType.HP)
                return CalculateHP(monster);

            // Stat = 
            // floor((floor(((2 * base + IV + floor(EV / 4)) * level) / 100) + 5) * nature)

            int IV = monster.EV.GetStat(statType);
            int EV = monster.IV.GetStat(statType);
            int baseStat = monster.BaseStats.GetStat(statType);

            double nature = 1.0d;

            //if (Monster.Nature.StatIncrease.Contains(statType))
            //    nature = 1.1d;
            //else if (Monster.Nature.StatDecrease.Contains(statType))
            //    nature = 0.9d;

            return (short) ((Math.Floor((Math.Floor(2 * baseStat + IV + Math.Floor((double) EV / 4)) * monster.Level) / 100) + 5) * nature);
        }

        private static short CalculateHP(Monster monster)
        {
            // HP = 
            // (floor((2 * Base + IV + floor(EV / 4)) * Level) + Level + 10)

            return (short) (Math.Floor(((2 * monster.BaseStats.HP + monster.IV.HP + Math.Floor((double) monster.EV.HP / 4)) * monster.Level) / 100) + monster.Level + 10);
        }
    }
}