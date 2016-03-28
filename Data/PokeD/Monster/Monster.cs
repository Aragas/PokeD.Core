using System;
using System.Linq;
using System.Threading.Tasks;

using Aragas.Core.Data;

using MersenneTwister;

using PokeD.Core.Data.PokeApi;
using PokeD.Core.Data.PokeD.Monster.Data;
using PokeD.Core.Data.PokeD.Monster.Interfaces;

namespace PokeD.Core.Data.PokeD.Monster
{
    public class MonsterStaticData
    {
        public static Languages Language { get; set; } = Languages.English; // TODO: Move it


        public short ID { get; }
        public string Name { get; private set; }
        public MonsterTypes Types { get; private set; }

        public float MaleRate { get; private set; }
        public byte CatchRate { get; private set; }

        public MonsterStats BaseStats { get; private set; } = MonsterStats.Empty;
        public byte BaseFriendship { get; private set; }
        public MonsterAbilities Abilities { get; private set; }

        public MonsterHeldItem[] HeldItems { get; private set; }

        public MonsterExperienceType ExperienceType { get; private set; }

        public short RewardExperience { get; private set; }
        public MonsterStats RewardStats { get; private set; } = MonsterStats.Empty;

        public byte EggCycles { get; private set; }
        public MonsterEggGroups EggGroups { get; private set; }


        public byte LevelEvolveRequirement { get; private set; }

        //public EvolutionConditionModel[] EvolutionConditions;


        public MonsterStaticData(short id) { ID = id; }


        private static bool GetLocalizedName(Localization name) => ((Languages) new ResourceUri(name.language).Id) == Language;
        public static async Task<MonsterStaticData> LoadStaticDataPokeApiV2(short id)
        {
            var data = new MonsterStaticData(id);

            var pokemon = await PokeApiV2.GetPokemon(new ResourceUri($"api/v2/pokemon/{id}/", true));
            var pokemonSpecies = await PokeApiV2.GetPokemonSpecies(new ResourceUri($"api/v2/pokemon-species/{id}/", true));

            var abilities = await PokeApiV2.GetAbilities(pokemon.abilities.Select(ability => new ResourceUri(ability.ability)));
            var types = await PokeApiV2.GetTypes(pokemon.types.Select(type => new ResourceUri(type.type)));
            var eggGroups = await PokeApiV2.GetEggGroups(pokemonSpecies.egg_groups.Select(eggGroup => new ResourceUri(eggGroup)));
            var heldItems = await PokeApiV2.GetItems(pokemon.held_items.Select(heldItem => new ResourceUri(heldItem.item)));
            //var moves = await PokeApiV2.GetMoves(pokemon.moves.Select(move => new ResourceUri(move.move)));

            data.Name = pokemonSpecies.names.Find(GetLocalizedName).name;
            data.Types = new MonsterTypes(types.Select(type => new MonsterType(type.id, type.names.Find(GetLocalizedName).name)).ToArray());

            data.MaleRate = (pokemonSpecies.gender_rate != -1) ? (8 - pokemonSpecies.gender_rate) / 8.0f : -1.0f;
            data.CatchRate = (byte) pokemonSpecies.capture_rate;

            data.BaseStats = new MonsterStats(
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.HP).base_stat,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.Attack).base_stat,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.Defense).base_stat,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.SpecialAttack).base_stat,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.SpecialDefense).base_stat,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.Speed).base_stat);
            data.BaseFriendship = (byte) pokemonSpecies.base_happiness;
            data.Abilities = new MonsterAbilities(abilities.Select(ability => new MonsterAbility(ability.id, ability.names.Find(GetLocalizedName).name)).ToArray());

            data.HeldItems = heldItems.Select(heldItem => new MonsterHeldItem(heldItem.id,
                            heldItem.names.Find(GetLocalizedName).name,
                            pokemon.held_items.Find(item => item.item.name == heldItem.name).version_details.Last().rarity)).ToArray();

            //moves[0].


            data.ExperienceType = (MonsterExperienceType) new ResourceUri(pokemonSpecies.growth_rate).Id;

            data.RewardExperience = (short) pokemon.base_experience;
            data.RewardStats = new MonsterStats(
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.HP).effort,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.Attack).effort,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.Defense).effort,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.SpecialAttack).effort,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.SpecialDefense).effort,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).Id == (int) MonsterStatType.Speed).effort);

            data.EggCycles = (byte) pokemonSpecies.hatch_counter;
            data.EggGroups = new MonsterEggGroups(eggGroups.Select(eggGroup => new MonsterEggGroup(eggGroup.id, eggGroup.names.Find(GetLocalizedName).name)).ToArray());


            return data;
        }
    }
    public class MonsterInstanceData
    {
        public MonsterStaticData StaticData { get; }

        public short Species { get; }
        public ushort SecretID { get; }
        public MonsterCatchInfo CatchInfo { get; set; } = MonsterCatchInfo.Empty;

        public uint PersonalityValue { get; }

        public MonsterGender Gender => StaticData.MaleRate < 0.0f ? MonsterGender.Genderless : (PersonalityValue % 256 < (byte) (StaticData.MaleRate * byte.MaxValue) ? MonsterGender.Female : MonsterGender.Male);

        public bool FirstAbility => (PersonalityValue / 65536) % 2 == 0;
        public bool IsShiny => (PersonalityValue % 65536) < 16;
        public byte Characteristic => (byte) (PersonalityValue % 6);
        public MonsterAbility Ability => FirstAbility ? StaticData.Abilities.Ability_0 : StaticData.Abilities.Ability_1;
        public byte Nature { get; }

        public int Experience { get; set; }
        public byte Level => MonsterExperienceCalculator.LevelForExperienceValue(StaticData.ExperienceType, Experience);
        public int EggSteps { get; set; }

        public MonsterStats IV { get; set; } = MonsterStats.Empty;
        public MonsterStats EV { get; set; } = MonsterStats.Empty;
        public MonsterStats HiddenEV { get; set; } = MonsterStats.Empty;

        public short CurrentHP { get; set; }
        public short StatusEffect { get; set; }

        public byte Affection { get; set; }
        public byte Friendship { get; set; }

        public MonsterMoves Moves { get; set; } = MonsterMoves.Empty;

        public short HeldItem { get; set; }

        public Vector2[] SpindaSpots => BitConverter.GetBytes(PersonalityValue).Select(b => new Vector2(b & 0x0F, b >> 4)).ToArray();
        public byte WurmplesEvolution => (byte) (PersonalityValue / 65536);

        public MonsterInstanceData(short species)
        {
            Species = species;

            StaticData = MonsterStaticData.LoadStaticDataPokeApiV2(Species).Result;

            var random = new MersenneTwisterRandom();
            var thirtyBits = (uint) random.Next(1 << 30);
            var twoBits = (uint) random.Next(1 << 2);
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
        public MonsterInstanceData(short species, ushort secretId, uint personalityValue, byte nature)
        {
            Species = species;
            SecretID = secretId;

            StaticData = MonsterStaticData.LoadStaticDataPokeApiV2(Species).Result;

            PersonalityValue = personalityValue;
            Nature = nature;
        }
        public MonsterInstanceData(short species, MonsterGender gender, bool isShiny, short ability, byte nature)
        {
            StaticData = MonsterStaticData.LoadStaticDataPokeApiV2(species).Result;

            Species = species;
            PersonalityValue = StaticData.Abilities.Contains(ability) ? GenerateRandom(gender, isShiny, ability) : 0;
            Nature = nature;
        }
        private uint GenerateRandom(MonsterGender gender, bool isShiny, short ability)
        {
            Generate:
            var random = new MersenneTwisterRandom();
            var thirtyBits = (uint) random.Next(1 << 30);
            var twoBits = (uint) random.Next(1 << 2);
            var result = (thirtyBits << 2) | twoBits;

            Check:
            var Gender = StaticData.MaleRate < 0.0f ? MonsterGender.Genderless : (result % 256 < (byte) (StaticData.MaleRate * byte.MaxValue) ? MonsterGender.Male : MonsterGender.Female);
            var FirstAbility = (result / 65536 % 2) == 0;
            var IsShiny = (result % 65536) < 16;

            if(gender != Gender || ((ability == StaticData.Abilities.Ability_0.ID) != FirstAbility) || isShiny != IsShiny)
                goto Generate;

            return result;
        }
        private static byte GenerateNature() => (byte) new MersenneTwisterRandom().Next(25);


        public bool IsValid() => (PersonalityValue != 0) ||
                                 StaticData.Abilities.Contains(Ability) ||
                                 IV.IsValidIV() ||
                                 EV.IsValidEV();
    }

    public class Monster : IMonsterInfo, IMonsterBaseInfo, IMonsterBattleInfo
    {
        public MonsterInstanceData InstanceData { get; }
        public MonsterStaticData StaticData => InstanceData.StaticData;


        public short Species => InstanceData.Species;
        public string DisplayName => !string.IsNullOrWhiteSpace(CatchInfo.Nickname) ? CatchInfo.Nickname : StaticData.Name;
        public MonsterTypes Types => StaticData.Types;
        public MonsterCatchInfo CatchInfo { get { return InstanceData.CatchInfo; } set { InstanceData.CatchInfo = value; } }

        public MonsterGender Gender => InstanceData.Gender;
        public MonsterAbility Ability => InstanceData.Ability;
        public byte Nature => InstanceData.Nature;
        public bool IsShiny => InstanceData.IsShiny;
        //public byte Characteristic => InstanceData.Characteristic;
        
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

        public Monster(short id)
        {
            InstanceData = new MonsterInstanceData(id);
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

        public bool IsValid()
        {
#if NOPOKEAPI
            return true;
#else
            return InstanceData.IsValid();
#endif
        }
    }
}
