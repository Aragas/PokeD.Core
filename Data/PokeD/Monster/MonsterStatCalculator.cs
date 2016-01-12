using System;

using PokeD.Core.Data.PokeD.Monster.Data;

namespace PokeD.Core.Data.PokeD.Monster
{
    public static class MonsterStatCalculator
    {
        public static MonsterStats CalculateStats(MonsterInstanceData instanceData)
        {
            var hp = CalculateStat(instanceData, MonsterStatType.HP);
            var attack = CalculateStat(instanceData, MonsterStatType.Attack);
            var defence = CalculateStat(instanceData, MonsterStatType.Defense);
            var spAttack = CalculateStat(instanceData, MonsterStatType.SpecialAttack);
            var spDefence = CalculateStat(instanceData, MonsterStatType.SpecialDefense);
            var speed = CalculateStat(instanceData, MonsterStatType.Speed);

            return new MonsterStats(hp, attack, defence, spAttack, spDefence, speed);
        }

        public static short CalculateStat(MonsterInstanceData instanceData, MonsterStatType statType)
        {
            if (statType == MonsterStatType.HP)
                return CalculateHP(instanceData);

            // Stat = 
            // floor((floor(((2 * base + IV + floor(EV / 4)) * level) / 100) + 5) * nature)

            int IV = instanceData.IV.GetStat(statType);
            int EV = instanceData.EV.GetStat(statType);
            int baseStat = instanceData.StaticData.BaseStats.GetStat(statType);

            double nature = 1.0d;

            //if (Monster.Nature.StatIncrease.Contains(statType))
            //    nature = 1.1d;
            //else if (Monster.Nature.StatDecrease.Contains(statType))
            //    nature = 0.9d;

            return (short) ((Math.Floor((Math.Floor(2 * baseStat + IV + Math.Floor((double) EV / 4)) * instanceData.Level) / 100) + 5) * nature);
        }
        private static short CalculateHP(MonsterInstanceData instanceData)
        {
            // HP = 
            // (floor((2 * Base + IV + floor(EV / 4)) * Level) + Level + 10)

            return (short) (Math.Floor(((2 * instanceData.StaticData.BaseStats.HP + instanceData.IV.HP + Math.Floor((double)instanceData.EV.HP / 4)) * instanceData.Level) / 100) + instanceData.Level + 10);
        }
    }
}