using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Aragas.Core.Data;
using Aragas.Core.Wrappers;

//using CsvHelper;

using MersenneTwister;

using PCLStorage;

using PokeD.Core.Data.PokeD.Monster.Data;
using PokeD.Core.Data.PokeD.Monster.Interfaces;
using PokeD.Core.Extensions;

namespace PokeD.Core.Data.PokeD.Monster
{
    public class MonsterStaticData
    {
        private static Dictionary<int, MonsterStaticData> Cache { get; } = new Dictionary<int, MonsterStaticData>(); 

        public short ID { get; }
        public string Name { get; private set; }
        public MonsterType Types { get; private set; }

        public byte MaleMax { get; private set; }
        public byte CatchRate { get; private set; }

        public MonsterStats BaseStats { get; private set; }
        public byte BaseFriendship { get; private set; }

        public short[] HeldItems { get; private set; }

        public MonsterExperienceType ExperienceType { get; private set; }

        public short RewardExperience { get; private set; }
        public MonsterStats RewardEV { get; private set; } = MonsterStats.Empty;


        public byte EggCycles { get; private set; }
        public MonsterEggGroup EggGroups { get; private set; }
        public bool CanBreed => EggGroups.EggGroup_0 != Data.EggGroups.Undiscovered && EggGroups.EggGroup_1 != Data.EggGroups.Undiscovered;


        public byte LevelEvolveRequirement { get; private set; }

        //public EvolutionConditionModel[] EvolutionConditions;


        public MonsterStaticData(short id) { ID = id; }


        public static MonsterStaticData LoadStaticDataCSV(short id)
        {
            if (Cache.ContainsKey(id))
                return Cache[id];


            var data = new MonsterStaticData(id);
            data.MaleMax = 31;

            LoadCSV("Names.csv", id, ref data, (staticData, reader) => staticData.Name = reader[1]);

            LoadCSV("Gender.csv", id, ref data, (staticData, reader) => staticData.MaleMax = byte.Parse(reader[1]));

            LoadCSV("BaseSTAT.csv", id, ref data, (staticData, reader) =>
            {
                var hp = short.Parse(reader[1]);
                var att = short.Parse(reader[2]);
                var def = short.Parse(reader[3]);
                var spAtt = short.Parse(reader[4]);
                var spDef = short.Parse(reader[5]);
                var spd = short.Parse(reader[6]);
                staticData.BaseStats = new MonsterStats(hp, att, def, spAtt, spDef, spd);
            });

            LoadCSV("Types.csv", id, ref data, (staticData, reader) =>
            {
                var type1 = reader[1];
                var type2 = reader[2];

                staticData.Types = !string.IsNullOrEmpty(type2)
                    ? new MonsterType((Types)Enum.Parse(typeof(Types), type1), (Types)Enum.Parse(typeof(Types), type2))
                    : new MonsterType((Types)Enum.Parse(typeof(Types), type1));
            });

            LoadCSV("ExperienceType.csv", id, ref data, (staticData, reader) => staticData.ExperienceType = (MonsterExperienceType) Enum.Parse(typeof (MonsterExperienceType), reader[1]));

            LoadCSV("BaseFriendship.csv", id, ref data, (staticData, reader) => staticData.BaseFriendship = byte.Parse(reader[1]));

            LoadCSV("Eggs.csv", id, ref data, (staticData, reader) =>
            {
                var egg1 = reader[1];
                var egg2 = reader[2];
                staticData.EggGroups = egg2 != "—"
                    ? new MonsterEggGroup((EggGroups)Enum.Parse(typeof(EggGroups), egg1), (EggGroups)Enum.Parse(typeof(EggGroups), egg2))
                    : new MonsterEggGroup((EggGroups)Enum.Parse(typeof(EggGroups), egg1));

                staticData.EggCycles = byte.Parse(reader[3]);
            });

            LoadCSV("EffortValues.csv", id, ref data, (staticData, reader) =>
            {
                staticData.RewardExperience = short.Parse(reader[1]);

                var hp = short.Parse(reader[2]);
                var att = short.Parse(reader[3]);
                var def = short.Parse(reader[4]);
                var spAtt = short.Parse(reader[5]);
                var spDef = short.Parse(reader[6]);
                var spd = short.Parse(reader[7]);
                staticData.RewardEV = new MonsterStats(hp, att, def, spAtt, spDef, spd);
            });

            Cache.Add(id, data);
            return data;
        }
        private static void LoadCSV(string filename, int id, ref MonsterStaticData data, Action<MonsterStaticData, string[]> func)
        {
            using (var stream = FileSystemWrapper.DatabaseFolder.GetFileAsync(filename).Result.OpenAsync(FileAccess.Read).Result)
            using (var streamReader = new StreamReader(stream))
            {
                var line = streamReader.ReadLine(); // skip first

                while ((line = streamReader.ReadLine()) != null)
                {
                    var array = line.Split(',');

                    if (array[0] != id.ToString() && array[0] != id.ToString("000"))
                        continue;

                    func(data, array);
                    break;
                }
            }
        }

        public static MonsterStaticData LoadStaticDataPokeApi(short id)
        {
            if (Cache.ContainsKey(id))
                return Cache[id];


            var data = new MonsterStaticData(id);

            var pokemon = PokeApi.GetPokemon(new ResourceUri($"/api/v1/pokemon/{id}/"));

            //var abilities = PokeApi.GetAbilities(pokemon.abilities.Select(ability => new ResourceUri(ability.resource_uri)).ToArray());
            //var moves = PokeApi.GetMoves(pokemon.moves.Select(move => new ResourceUri(move.resource_uri)).ToArray());
            //var types = PokeApi.GetTypes(pokemon.types.Select(type => new ResourceUri(type.resource_uri)).ToArray());
            //var eggGroups = PokeApi.GetEggGroups(pokemon.egg_groups.Select(eggGroup => new ResourceUri(eggGroup.resource_uri)).ToArray());


            data.Name = pokemon.name;
            //data.Types = new MonsterType(types.Select(type => (Types) type.id).ToArray());
            data.Types = new MonsterType(pokemon.types.Select(type => (Types) Enum.Parse(typeof (Types), type.name, true)).ToArray());

            data.BaseStats = new MonsterStats((short) pokemon.hp, (short) pokemon.attack, (short) pokemon.defense, (short) pokemon.sp_atk, (short) pokemon.sp_def, (short) pokemon.speed);

            if(!string.IsNullOrEmpty(pokemon.male_female_ratio))
                data.MaleMax = byte.Parse(pokemon.male_female_ratio);
            else
                LoadCSV("Gender.csv", id, ref data, (staticData, reader) => staticData.MaleMax = byte.Parse(reader[1]));

            if (pokemon.happiness != 0)
                data.BaseFriendship = (byte) pokemon.happiness;
            else
                LoadCSV("BaseFriendship.csv", id, ref data, (staticData, reader) => staticData.BaseFriendship = byte.Parse(reader[1]));

            data.CatchRate = (byte) pokemon.catch_rate;

            if (!string.IsNullOrEmpty(pokemon.growth_rate))
                data.ExperienceType = (MonsterExperienceType) Enum.Parse(typeof (MonsterExperienceType), pokemon.growth_rate.RemoveWhitespace(), true);
            else
                LoadCSV("ExperienceType.csv", id, ref data, (staticData, reader) => staticData.ExperienceType = (MonsterExperienceType)Enum.Parse(typeof(MonsterExperienceType), reader[1]));

            if (pokemon.egg_cycles != 0)
                data.EggCycles = (byte)pokemon.egg_cycles;
            else
                LoadCSV("Eggs.csv", id, ref data, (staticData, reader) => staticData.EggCycles = byte.Parse(reader[3]));

            //data.EggGroups = new MonsterEggGroup(eggGroups.Select(eggGroup => (EggGroups) eggGroup.id).ToArray());
            data.EggGroups = new MonsterEggGroup(pokemon.egg_groups.Select(eggGroup => (EggGroups) Enum.Parse(typeof (EggGroups), eggGroup.name, true)).ToArray());

            data.RewardExperience = (short) pokemon.exp;

            #region RewardEV

            if (!string.IsNullOrEmpty(pokemon.ev_yield))
            {
                var number = pokemon.ev_yield.Split(' ')[0];
                var typeString = string.Join("", pokemon.ev_yield.Split(' ').Skip(1));
                var type = (MonsterStatType) Enum.Parse(typeof (MonsterStatType), typeString, true);
                switch (type)
                {

                }
                //data.RewardEV = pokemon.ev_yield
            }
            else
            {
                LoadCSV("EffortValues.csv", id, ref data, (staticData, reader) =>
                {
                    var hp = short.Parse(reader[2]);
                    var att = short.Parse(reader[3]);
                    var def = short.Parse(reader[4]);
                    var spAtt = short.Parse(reader[5]);
                    var spDef = short.Parse(reader[6]);
                    var spd = short.Parse(reader[7]);
                    staticData.RewardEV = new MonsterStats(hp, att, def, spAtt, spDef, spd);
                });
            }

            #endregion RewardEV

            if (!string.IsNullOrEmpty(pokemon.male_female_ratio))
                ;
            else
                LoadCSV("Gender.csv", id, ref data, (staticData, reader) => staticData.MaleMax = byte.Parse(reader[1]));

            data.LevelEvolveRequirement = (byte) pokemon.evolutions.MinOrDefault(evolution => evolution.level);


            Cache.Add(id, data);
            return data;
        }

        public static void LoadAllMonsters(int maxNum = 721)
        {
            for (short i = 1; i <= maxNum; i++)
                LoadStaticDataCSV(i);
        }
    }
    public class MonsterInstanceData
    {
        public MonsterStaticData StaticData { get; }

        public short ID { get; }
        public MonsterCatchInfo CatchInfo { get; set; } = new MonsterCatchInfo();

        private uint PersonalityValue { get; }
        public MonsterGender Gender => StaticData.MaleMax == byte.MaxValue ? MonsterGender.Genderless : (PersonalityValue % 256 < StaticData.MaleMax ? MonsterGender.Male : MonsterGender.Female);

        //public short Ability => (short) (PersonalityValue / 65536 % 2);
        public bool OneAbility => (PersonalityValue / 65536 % 2) != 0;
        public bool IsShiny => (PersonalityValue % 65536) < 16;
        public byte Characteristic => (byte)(PersonalityValue % 6);
        public short[] Abilities { get; set; }
        public byte Nature { get; }

        public int Experience { get; set; }
        public byte Level => MonsterExperienceCalculator.LevelForExperienceValue(StaticData.ExperienceType, Experience);
        public int EggSteps { get; set; }

        public MonsterStats BaseStats => StaticData.BaseStats;
        public MonsterStats IV { get; set; } = MonsterStats.Empty;
        public MonsterStats EV { get; set; } = MonsterStats.Empty;
        public MonsterStats HiddenEV { get; set; } = MonsterStats.Empty;

        public short CurrentHP { get; set; }
        public short StatusEffect { get; set; }

        public byte Affection { get; set; }
        public byte Friendship { get; set; }

        public MonsterMoves Moves { get; set; }

        public short HeldItem { get; set; }

        public Vector2[] SpindaSpots => BitConverter.GetBytes(PersonalityValue).Select(b => new Vector2(b & 0x0F, b >> 4)).ToArray();
        public byte WurmplesEvolution => (byte) (PersonalityValue / 65536);

        public MonsterInstanceData(short id, string nickname, MonsterGender gender, bool isShiny, byte nature)
        {
            ID = id;

            StaticData = MonsterStaticData.LoadStaticDataPokeApi(ID);

            CatchInfo.Nickname = string.IsNullOrEmpty(nickname) ? StaticData.Name : nickname;
            
            PersonalityValue = GenerateRandom(gender, isShiny);

            Nature = nature;
        }
        private uint GenerateRandom(MonsterGender gender, bool isShiny)
        {
            Generate:
            var random = new MersenneTwisterRandom();
            var thirtyBits = (uint) random.Next(1 << 30);
            var twoBits = (uint) random.Next(1 << 2);
            var result = (thirtyBits << 2) | twoBits;

            Check:
            var Gender = StaticData.MaleMax == byte.MaxValue ? MonsterGender.Genderless : (result % 256 < StaticData.MaleMax ? MonsterGender.Male : MonsterGender.Female);
            var OneAbility = (result / 65536 % 2) != 0;
            var IsShiny = (result % 65536) < 16;

            if(gender != Gender || !OneAbility || isShiny != IsShiny)
            //if(!OneAbility || IsShiny != isShiny)
                goto Generate;

            return result;
        }

        public MonsterInstanceData(short id, string nickname = null)
        {
            ID = id;
            CatchInfo.Nickname = nickname;

            StaticData = MonsterStaticData.LoadStaticDataPokeApi(ID);

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
        public MonsterInstanceData InstanceData { get; }
        public MonsterStaticData StaticData => InstanceData.StaticData;


        public short ID => InstanceData.ID;
        public string DisplayName => !string.IsNullOrWhiteSpace(CatchInfo.Nickname) ? CatchInfo.Nickname : StaticData.Name;
        public MonsterType Types => StaticData.Types;
        public MonsterCatchInfo CatchInfo { get { return InstanceData.CatchInfo; } set { InstanceData.CatchInfo = value; } }

        public MonsterGender Gender => InstanceData.Gender;
        public short[] Abilities => InstanceData.Abilities;
        public byte Nature => InstanceData.Nature;
        public bool IsShiny => InstanceData.IsShiny;
        public byte Characteristic => InstanceData.Characteristic;
        
        public int Experience { get { return InstanceData.Experience; } set { InstanceData.Experience = value; } }
        public byte Level => InstanceData.Level;
        public int EggSteps { get { return InstanceData.EggSteps; } set { InstanceData.EggSteps = value; } }

        //internal MonsterStats BaseStats => InstanceData.BaseStats;
        //internal MonsterStats EV { get { return InstanceData.EV; } set { InstanceData.EV = value; } }
        //internal MonsterStats IV { get { return InstanceData.IV; } set { InstanceData.IV = value; } }
        public MonsterStats Stats => MonsterStatCalculator.CalculateStats(InstanceData);

        public short CurrentHP { get { return InstanceData.CurrentHP; } set { InstanceData.CurrentHP = value; } }
        public short StatusEffect { get { return InstanceData.StatusEffect; } set { InstanceData.StatusEffect = value; } }

        public byte Affection { get { return InstanceData.Affection; } set { InstanceData.Affection = value; } }
        public byte Friendship { get { return InstanceData.Friendship; } set { InstanceData.Friendship = value; } }
        
        public MonsterMoves Moves { get { return InstanceData.Moves; } set { InstanceData.Moves = value; } }
        
        public short HeldItem { get { return InstanceData.HeldItem; } set { InstanceData.HeldItem = value; } }

        public Monster(short id, string nickname = null)
        {
            InstanceData = new MonsterInstanceData(id, nickname);
        }

        public Monster(Monster maleParent, Monster femaleParent)
        {

        }


        public Monster(IMonsterBaseInfo info)
        {

        }

        public Monster(MonsterInstanceData instanceData)
        {
            InstanceData = instanceData;
        }
    }
}
