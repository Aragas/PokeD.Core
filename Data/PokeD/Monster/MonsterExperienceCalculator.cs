using System;

using PokeD.Core.Data.PokeD.Trainer;

namespace PokeD.Core.Data.PokeD.Monster
{
    public enum MonsterExperienceType
    {
        Fast,
        Erratic,
        Fluctuating,
        MediumFast,
        MediumSlow,
        Slow
    }
    public static class MonsterExperienceCalculator
    {
        public static int GainExperience(IOpponentInfo trainer, Monster victorious, Monster fainted, bool hasParticipatedAndExpShare = false, bool useScaled = false)
        {
            double a = fainted.TrainerID == 0 ? 1 : 1.5; // is wild
            double b = fainted.StaticData.BaseExperience;
            double e = victorious.HeldItem == 0 ? 1.5 : 0;
            double f = victorious.Affection >= 2 ? 1.2 : 1;
            double l = fainted.Level;
            double lp = victorious.Level;
            double p = 1;
            double s = hasParticipatedAndExpShare ? 2 : 1;
            double t = trainer.TrainerID == victorious.TrainerID ? 1.5 : 1;
            double v = victorious.Level > victorious.StaticData.LevelEvolveRequirement ? 1.2 : 1;

            if (!useScaled)
                return (int)((a * t * b * e * l * p * f * v) / 7 * s);
            else
                return (int)((((a * b * l) / 5 * s) * (Math.Pow(2 * l + 10, 2.5) / Math.Pow(l + lp + 10, 2.5)) + 1) * t * e * p);
        }

        public static byte LevelForExperienceValue(MonsterExperienceType experienceType, int experience)
        {
            // returns level 1 if no experience (or negative value):
            if (experience <= 0)
                return 1;

            byte level = 1;
            while (ExperienceNeededForLevel(experienceType, level) <= experience)
                level++;

            return level;
        }
        public static int ExperienceNeededForLevel(MonsterExperienceType experienceType, int level)
        {
            switch (experienceType)
            {
                case MonsterExperienceType.Erratic:
                    return (int) Math.Round(ExperienceNeededForLevelErratic(level));
                case MonsterExperienceType.Fast:
                    return (int) Math.Round(ExperienceNeededForLevelFast(level));
                case MonsterExperienceType.MediumFast:
                    return (int) Math.Round(ExperienceNeededForLevelMediumFast(level));
                case MonsterExperienceType.MediumSlow:
                    return (int) Math.Round(ExperienceNeededForLevelMediumSlow(level));
                case MonsterExperienceType.Slow:
                    return (int) Math.Round(ExperienceNeededForLevelSlow(level));
                case MonsterExperienceType.Fluctuating:
                    return (int) Math.Round(ExperienceNeededForLevelFluctuating(level));
                default:
                    return (int) Math.Round(ExperienceNeededForLevelMediumFast(level));
            }
        }
        
        private static double ExperienceNeededForLevelErratic(double level)
        {
            // EXP = 
            // level <= 50:         ((pow(level, 3) * (100 - level)) / 50)
            // 50 <= level <= 68:   ((pow(level, 3) * (150 - level)) / 100)
            // 68 <= level <= 98:   ((pow(level, 3) * floor((1911 - (10 * level)) / 3)) / 500)
            // 98 <= level <= 100:  ((pow(level, 3) * (160 - level)) / 100)

            if (level <= 50)
                return (Math.Pow(level, 3) * (100 - level)) / 50;
            else if (50 <= level && level <= 68)
                return (Math.Pow(level, 3) * (150 - level)) / 100;
            else if (68 <= level && level <= 98)
                return (Math.Pow(level, 3) * Math.Floor((1911 - (10 * level)) / 3)) / 500;
            else if (98 <= level && level <= 100)
                return (Math.Pow(level, 3) * (160 - level)) / 100;
            else
                throw new Exception();
        }
        private static double ExperienceNeededForLevelFast(double level)
        {
            // EXP = 
            // ((4 * pow(level, 3)) / 5)

            return (4 * Math.Pow(level, 3)) / 5;
        }
        private static double ExperienceNeededForLevelMediumFast(double level)
        {
            // EXP =
            // (pow(level, 3))

            return Math.Pow(level, 3);
        }
        private static double ExperienceNeededForLevelMediumSlow(double level)
        {
            // EXP = 
            // (((6 / 5) * pow(level, 3)) - (15 * pow(level, 2)) + (100 * level) - 140)

            return ((6.0f / 5.0f) * Math.Pow(level, 3)) - (15 * Math.Pow(level, 2)) + (100 * level) - 140;
        }
        private static double ExperienceNeededForLevelSlow(double level)
        {
            // EXP = 
            // ((5 * pow(level, 3)) / 4)

            return (5 * Math.Pow(level, 3)) / 4;
        }
        private static double ExperienceNeededForLevelFluctuating(double level)
        {
            // EXP = 
            // level <= 15: (pow(level, 3) * ((floor((level + 1) / 3) + 24) / 50))
            // 15 <= level <= 36: (pow(level, 3) * ((level + 14) / 50))
            // 36 <= level <= 100: (pow(level, 3) * ((floor(level / 2) + 32) / 50))

            if (level <= 15)
                return Math.Pow(level, 3) * ((Math.Floor((level + 1) / 3) + 24) / 50);
            else if (15 <= level && level <= 36)
                return Math.Pow(level, 3) * ((level + 14) / 50);
            else if (36 <= level && level <= 100)
                return Math.Pow(level, 3) * ((Math.Floor(level / 2) + 32) / 50);
            else
                throw new Exception();
        }
    }
}