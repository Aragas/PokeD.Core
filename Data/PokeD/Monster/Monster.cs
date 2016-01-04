using System;
using System.Linq;

using Aragas.Core.Data;

using MersenneTwister;

namespace PokeD.Core.Data.PokeD.Monster
{
    public enum MonsterGender { Male, Female, Genderless }

    public class MonsterStaticData
    {
        public string ID { get; }
        public string Name { get; }

        public float GenderPercentage { get; }

        public MonsterExperienceType ExperienceType { get; }

        public byte EggCycles { get; }
        public int[] EggGroups { get; }
        //public bool CanBreed => EggGroups.Any(eg => eg == Undiscovered);

        public MonsterStats RewardEV { get; }

        public byte BaseFriendship { get; }

        public short[] HeldItems { get; }


        public short BaseExperience { get; set; }
        public byte LevelEvolveRequirement { get; set; }


        //public PokedexEntryModel PokedexEntry;

        //public EvolutionConditionModel[] EvolutionConditions;

        public static MonsterStaticData LoadStaticData(short id)
        {
            return null;
        }
    }
    public class MonsterInstanceData
    {
        public MonsterStaticData StaticData { get; }

        public short ID { get; }
        public string Nickname { get; }
        public short TrainersID { get; }

        public MonsterCatchInfo CatchInfo { get; set; }
        private uint PersonalityValue { get; }
        public MonsterGender Gender => StaticData.GenderPercentage < 0.0f
            ? MonsterGender.Genderless
            : ((float)(PersonalityValue % 256) / 255.0f > StaticData.GenderPercentage
                ? MonsterGender.Male
                : MonsterGender.Female);
        public short Ability => (short) (PersonalityValue / 65536 % 2);
        public bool IsShiny => (PersonalityValue % 65536) < 16;
        public byte Characteristic => (byte)(PersonalityValue % 6);
        public byte Nature { get; }

        public int Experience { get; set; }
        public int EggSteps { get; set; }

        public MonsterStats BaseStats { get; set; }
        public MonsterStats IV { get; set; }
        public MonsterStats EV { get; set; }
        public MonsterStats HiddenEV { get; set; }

        public short CurrentHP { get; set; }
        public short StatusEffect { get; set; }

        public byte Affection { get; set; }
        public byte Friendship { get; set; }

        public MonsterMoves Moves { get; set; }

        public short HeldItem { get; set; }

        public Vector2[] SpindaSpots => BitConverter.GetBytes(PersonalityValue).Select(b => new Vector2(b & 0x0F, b >> 4)).ToArray();
        public byte WurmplesEvolution => (byte) (PersonalityValue / 65536);

        public MonsterInstanceData(short id, string nickname = null)
        {
            ID = id;
            Nickname = nickname;

            StaticData = MonsterStaticData.LoadStaticData(ID);

            var random = new MersenneTwisterRandom();
            var thirtyBits = (uint)random.Next(1 << 30);
            var twoBits = (uint)random.Next(1 << 2);
            PersonalityValue = (thirtyBits << 2) | twoBits;

            Nature = GenerateNature();

            IV = new MonsterStats(
                (short) random.Next(0, 31),
                (short) random.Next(0, 31),
                (short) random.Next(0, 31),
                (short) random.Next(0, 31),
                (short) random.Next(0, 31),
                (short) random.Next(0, 31));
        }

        private static byte GenerateNature() => (byte) new MersenneTwisterRandom().Next(25);
        private static int PerformanceStars(byte day, byte attribute, byte pattribute)
        {
            //(((day + attribute + 3) × (day - attribute + 7) + pattribute) % 10) × 2 - 9

            var sum = (((day + attribute + 3) * (day - attribute + 7) + pattribute) % 10) * 2 - 9;

            if (sum < -120)
                return -4;
            else if(sum < -80)
                return -3;
            else if(sum < -40)
                return -2;
            else if(sum < -15)
                return -1;
            else if(sum < 14)
                return 0;
            else if(sum < 39)
                return 1;
            else if(sum < 79)
                return 2;
            else if(sum < 119)
                return 3;
            else
                return 4;
        }
    }

    public class Monster : IMonsterInfo, IMonsterBaseInfo, IMonsterBattleInfo
    {
        private MonsterInstanceData InstanceData { get; }
        public MonsterStaticData StaticData => InstanceData.StaticData;


        public short ID => InstanceData.ID;
        public string DisplayName => !string.IsNullOrWhiteSpace(InstanceData.Nickname) ? InstanceData.Nickname : StaticData.Name;
        public short TrainerID => InstanceData.TrainersID;

        public MonsterCatchInfo CatchInfo { get { return InstanceData.CatchInfo; } set { InstanceData.CatchInfo = value; } }
        public MonsterGender Gender => InstanceData.Gender;
        public short Ability => InstanceData.Ability;
        public byte Nature => InstanceData.Nature;
        public bool IsShiny => InstanceData.IsShiny;
        public byte Characteristic => InstanceData.Characteristic;
        
        public int Experience { get { return InstanceData.Experience; } set { InstanceData.Experience = value; } }
        public byte Level => MonsterExperienceCalculator.LevelForExperienceValue(StaticData.ExperienceType, Experience);
        public int EggSteps { get { return InstanceData.EggSteps; } set { InstanceData.EggSteps = value; } }

        internal MonsterStats BaseStats { get { return InstanceData.BaseStats; } set { InstanceData.BaseStats = value; } }
        internal MonsterStats EV { get { return InstanceData.EV; } set { InstanceData.EV = value; } }
        internal MonsterStats IV { get { return InstanceData.IV; } set { InstanceData.IV = value; } }
        public MonsterStats Stats => MonsterStatCalculator.CalculateStats(this);

        public short CurrentHP { get { return InstanceData.CurrentHP; } set { InstanceData.CurrentHP = value; } }
        public short StatusEffect { get { return InstanceData.StatusEffect; } set { InstanceData.StatusEffect = value; } }

        public byte Affection { get { return InstanceData.Affection; } set { InstanceData.Affection = value; } }
        public byte Friendship { get { return InstanceData.Friendship; } set { InstanceData.Friendship = value; } }
        
        public MonsterMoves Moves { get { return InstanceData.Moves; } set { InstanceData.Moves = value; } }
        
        public short HeldItem { get { return InstanceData.HeldItem; } set { InstanceData.HeldItem = value; } }

        public Monster(short id, string nickname = null, MonsterGender gender = MonsterGender.Genderless, byte level = 1, bool isShiny = false)
        {
            InstanceData = new MonsterInstanceData(id, nickname);
        }

        public Monster(Monster maleParent, Monster femaleParent)
        {

        }


        public Monster(IMonsterBaseInfo info)
        {

        }
    }
}
