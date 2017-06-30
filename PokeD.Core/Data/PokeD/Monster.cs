using System;
using System.Collections.Generic;
using System.Linq;

using MersenneTwister;

using PokeD.BattleEngine.Ability;
using PokeD.BattleEngine.Attack;
using PokeD.BattleEngine.Attack.Data;
using PokeD.BattleEngine.Battle.Data;
using PokeD.BattleEngine.EggGroup;
using PokeD.BattleEngine.Item;
using PokeD.BattleEngine.Item.Data;
using PokeD.BattleEngine.Monster;
using PokeD.BattleEngine.Monster.Data;
using PokeD.BattleEngine.Monster.Enums;
using PokeD.BattleEngine.Type;
using PokeD.Core.Data.P3D;
using PokeD.Core.Data.PokeApi;
using PokeD.Core.Extensions;

namespace PokeD.Core.Data.PokeD
{
    public class ByShed : EvolvesTo.IEvolutionCondition
    {
        public IList<EvolvesTo.ISubEvolutionCondition> SubConditions { get; } = new List<EvolvesTo.ISubEvolutionCondition>();

        public ByShed() { }

        public override string ToString() => $"By Shed";
    }

    public class ByTurnUpsideDown : EvolvesTo.ISubEvolutionCondition
    {
        public override string ToString() => $"Turn Upside Down";
    }


    public class MonsterStaticData : IMonsterStaticData
    {
        public static Languages Language { get; set; } = Languages.English;
        private static bool GetLocalizedName(Localization name) => ((Languages) new ResourceUri(name.language).ID) == Language;


        public short ID { get; }
        public string Name { get; }

        public Types Types { get; }
        public Abilities Abilities { get; }
        public EggGroups EggGroups { get; }
        public IList<IItemStaticData> HeldItems { get; }

        public int Height { get; }
        public int Weight { get; }
        
        public Stats BaseStats { get; }
        public byte BaseHappiness { get; }
        
        public byte CatchRate { get; }

        public float MaleRatio { get; }

        public int HatchCycles { get; }

        public bool IsBaby { get; }

        public bool HasGenderDifferences { get; }

        public Habitat Habitat { get; }

        public Color Color { get; }
        public Shape Shape { get; }

        public ExperienceType ExperienceType { get; }

        public short RewardExperience { get; }
        public Stats RewardStats { get; }

        public IList<EvolvesTo> EvolvesTo { get; } = new List<EvolvesTo>();

        public IList<AttackLearn> LearnableAttacks { get; } = new List<AttackLearn>();


        public MonsterStaticData(short id)
        {
            var pokemon         = PokeApiV2.GetPokemonAsync(new ResourceUri($"api/v2/pokemon/{id}/", true)).Result;
            var pokemonSpecies  = PokeApiV2.GetPokemonSpeciesAsync(new ResourceUri($"api/v2/pokemon-species/{id}/", true)).Result;
            //var abilities       = PokeApiV2.GetAbilities(pokemon.abilities.Select(ability => new ResourceUri(ability.ability)));
            //var types           = PokeApiV2.GetTypes(pokemon.types.Select(type => new ResourceUri(type.type)));
            //var eggGroups       = PokeApiV2.GetEggGroups(pokemonSpecies.egg_groups.Select(eggGroup => new ResourceUri(eggGroup)));
            //var heldItems       = PokeApiV2.GetItems(pokemon.held_items.Select(heldItem => new ResourceUri(heldItem.item)));
            var color           = PokeApiV2.GetPokemonColorAsync(new ResourceUri(pokemonSpecies.color)).Result;
            var habitat         = pokemonSpecies.habitat != null ? PokeApiV2.GetHabitatAsync(new ResourceUri(pokemonSpecies.habitat)).Result : null;
            var shape           = PokeApiV2.GetShapeAsync(new ResourceUri(pokemonSpecies.shape)).Result;
            var evolutionChain  = PokeApiV2.GetEvolutionChainAsync(new ResourceUri(pokemonSpecies.evolution_chain.url)).Result;



            ID = id;
            Name = pokemonSpecies.names.Find(GetLocalizedName).name;

            //Types = new Types(pokemon.types.Select(type => new MonsterTypeStaticData((byte) new ResourceUri(type.type).ID)).ToArray<ITypeStaticData>());
            Types = new Types(pokemon.types.Select(type => Cached<MonsterTypeStaticData>.Get((byte) new ResourceUri(type.type).ID)).ToArray<ITypeStaticData>());

            //Abilities = new Abilities(pokemon.abilities.Select(ability => new AbilityStaticData((short) new ResourceUri(ability.ability).ID)).ToArray<IAbilityStaticData>());
            //Abilities = new Abilities(pokemon.abilities.Select(ability => Cached<AbilityStaticData>.Get((short) new ResourceUri(ability.ability).ID)).ToArray<IAbilityStaticData>());
            Abilities = new Abilities(pokemon.abilities.Select(ability => new Ability((short) new ResourceUri(ability.ability).ID, ability.is_hidden)).ToArray<BaseAbility>());

            //EggGroups = new EggGroups(pokemonSpecies.egg_groups.Select(eggGroup => new EggGroupStaticData((byte) new ResourceUri(eggGroup).ID)).ToArray<IEggGroupStaticData>());
            EggGroups = new EggGroups(pokemonSpecies.egg_groups.Select(eggGroup => Cached<EggGroupStaticData>.Get((byte) new ResourceUri(eggGroup).ID)).ToArray<IEggGroupStaticData>());

            //HeldItems = pokemon.held_items.Select(heldItem => new ItemStaticData(new ResourceUri(heldItem.item).ID)).ToList<IItemStaticData>();
            HeldItems = pokemon.held_items.Select(heldItem => Cached<ItemStaticData>.Get(new ResourceUri(heldItem.item).ID)).ToList<IItemStaticData>();
            
            Height = pokemon.height;
            Weight = pokemon.weight;

            BaseStats = new Stats(
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.HP).base_stat,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.Attack).base_stat,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.Defense).base_stat,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.SpecialAttack).base_stat,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.SpecialDefense).base_stat,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.Speed).base_stat);
            BaseHappiness = (byte) pokemonSpecies.base_happiness;

            CatchRate = (byte) pokemonSpecies.capture_rate;

            MaleRatio = (pokemonSpecies.gender_rate != -1) ? (8 - pokemonSpecies.gender_rate) / 8.0f : -1.0f;

            HatchCycles = (byte) pokemonSpecies.hatch_counter;

            IsBaby = pokemonSpecies.is_baby;

            HasGenderDifferences = pokemonSpecies.has_gender_differences;

            Habitat = habitat != null ? new Habitat(habitat.id, habitat.names.Find(GetLocalizedName).name) : Habitat.None;

            Color = new Color(color.id, color.names.Find(GetLocalizedName).name);
            Shape = new Shape(shape.id, shape.names.Find(GetLocalizedName).name);

            ExperienceType = (ExperienceType) new ResourceUri(pokemonSpecies.growth_rate).ID;

            RewardExperience = (short) pokemon.base_experience;
            RewardStats = new Stats(
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.HP).effort,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.Attack).effort,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.Defense).effort,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.SpecialAttack).effort,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.SpecialDefense).effort,
                (short) pokemon.stats.Find(stat => new ResourceUri(stat.stat).ID == (int) StatType.Speed).effort);

            if (evolutionChain.chain.evolves_to.Any())
            {
                var chains = GetChains(evolutionChain.chain);
                var chain = chains.FirstOrDefault(c => ID == new ResourceUri(c.species).ID);

                if (chain != null)
                {
                    foreach (var evolvesTo in chain.evolves_to)
                    {
                        var list = new List<EvolvesTo.IEvolutionCondition>();
                        foreach (var evolutionDetail in evolvesTo.evolution_details)
                        {
                            var evolutionConditions = new List<EvolvesTo.ISubEvolutionCondition>();
                            
                            if (evolutionDetail.min_level != null)
                                evolutionConditions.Add(new EvolvesTo.ByLevel((byte) evolutionDetail.min_level));
                            
                            if (evolutionDetail.min_happiness != null)
                                evolutionConditions.Add(new EvolvesTo.ByHappiness((byte) evolutionDetail.min_happiness.Value));

                            if (evolutionDetail.min_affection != null)
                                evolutionConditions.Add(new EvolvesTo.ByAffection((byte) evolutionDetail.min_affection.Value));

                            if (evolutionDetail.min_beauty != null)
                                evolutionConditions.Add(new EvolvesTo.ByBeauty((byte) evolutionDetail.min_beauty));

                            if (evolutionDetail.known_move != null)
                                //evolutionConditions.Add(new EvolvesTo.ByAttack(new AttackStaticData((short) new ResourceUri(evolutionDetail.known_move).ID)));
                                evolutionConditions.Add(new EvolvesTo.ByAttack(Cached<AttackStaticData>.Get((short)new ResourceUri(evolutionDetail.known_move).ID)));
                            
                            if (evolutionDetail.known_move_type != null)
                                //evolutionConditions.Add(new EvolvesTo.ByKnownAttackType(new MonsterTypeStaticData((byte) new ResourceUri(evolutionDetail.known_move_type).ID)));
                                evolutionConditions.Add(new EvolvesTo.ByKnownAttackType(Cached<MonsterTypeStaticData>.Get((byte) new ResourceUri(evolutionDetail.known_move_type).ID)));

                            if (evolutionDetail.item != null)
                                //evolutionConditions.Add(new EvolvesTo.ByItem(new ItemStaticData(new ResourceUri(evolutionDetail.item).ID)));
                                evolutionConditions.Add(new EvolvesTo.ByItem(Cached<ItemStaticData>.Get(new ResourceUri(evolutionDetail.item).ID)));
                            
                            if (evolutionDetail.held_item != null)
                                //evolutionConditions.Add(new EvolvesTo.ByHeldItem(new ItemStaticData(new ResourceUri(evolutionDetail.held_item).ID)));
                                evolutionConditions.Add(new EvolvesTo.ByHeldItem(Cached<ItemStaticData>.Get(new ResourceUri(evolutionDetail.held_item).ID)));
                            
                            if (evolutionDetail.gender != null)
                                evolutionConditions.Add(new EvolvesTo.ByGender((Gender) evolutionDetail.gender));

                            if (evolutionDetail.location != null)
                                evolutionConditions.Add(new EvolvesTo.ByArea(null));

                            if (evolutionDetail.needs_overworld_rain)
                                evolutionConditions.Add(new EvolvesTo.ByWeather(Weather.Rain));

                            if (evolutionDetail.party_species != null)
                                evolutionConditions.Add(new EvolvesTo.ByMonsterInTeam((short) new ResourceUri(evolutionDetail.party_species).ID));

                            if (evolutionDetail.party_type != null)
                                ;

                            if (evolutionDetail.trade_species != null)
                                evolutionConditions.Add(new EvolvesTo.ByTradeMonster((short) new ResourceUri(evolutionDetail.trade_species).ID));

                            if (evolutionDetail.turn_upside_down)
                                evolutionConditions.Add(new ByTurnUpsideDown());

                            if (!string.IsNullOrEmpty(evolutionDetail.time_of_day))
                            {
                                if (Enum.TryParse(evolutionDetail.time_of_day, true, out EvolvesTo.ByTimeOfDay.TimeOfDay @enum))
                                    evolutionConditions.Add(new EvolvesTo.ByTimeOfDay(@enum));
                                else
                                    throw new Exception();
                            }

                            switch (new ResourceUri(evolutionDetail.trigger).ID)
                            {
                                case 1:
                                    list.Add(new EvolvesTo.ByLevelUp(evolutionConditions));
                                    break;

                                case 2:
                                    list.Add(new EvolvesTo.ByTrade(evolutionConditions));
                                    break;

                                case 3:
                                    list.Add(new EvolvesTo.ByItemUse(evolutionConditions));
                                    break;

                                case 4:
                                    list.Add(new ByShed());
                                    break;

                                default:
                                    break;
                            }
                        }

                        EvolvesTo.Add(new EvolvesTo(Cached<MonsterStaticData>.Get((short) new ResourceUri(evolvesTo.species).ID), list));
                    }
                }
            }

            foreach (var move in pokemon.moves)
            {
                if (move.version_group_details.Any())
                {
                    var vg = move.version_group_details.First();
                    switch (new ResourceUri(vg.move_learn_method).ID)
                    {
                        case 1:
                            //LearnableAttacks.Add(new AttackLearn(new AttackStaticData((short) new ResourceUri(move.move).ID), new AttackLearn.ByLevel((byte) vg.level_learned_at)));
                            LearnableAttacks.Add(new AttackLearn(Cached<AttackStaticData>.Get((short) new ResourceUri(move.move).ID), new AttackLearn.ByLevel((byte)vg.level_learned_at)));
                            break;

                        case 2:
                            //LearnableAttacks.Add(new AttackLearn(new AttackStaticData((short) new ResourceUri(move.move).ID), new AttackLearn.ByBreeding()));
                            LearnableAttacks.Add(new AttackLearn(Cached<AttackStaticData>.Get((short) new ResourceUri(move.move).ID), new AttackLearn.ByBreeding()));
                            break;

                        case 3:
                            //LearnableAttacks.Add(new AttackLearn(new AttackStaticData((short) new ResourceUri(move.move).ID), new AttackLearn.ByTutor()));
                            LearnableAttacks.Add(new AttackLearn(Cached<AttackStaticData>.Get((short) new ResourceUri(move.move).ID), new AttackLearn.ByTutor()));
                            break;

                        case 4:
                            //LearnableAttacks.Add(new AttackLearn(new AttackStaticData((short) new ResourceUri(move.move).ID), new AttackLearn.ByMachine()));
                            LearnableAttacks.Add(new AttackLearn(Cached<AttackStaticData>.Get((short) new ResourceUri(move.move).ID), new AttackLearn.ByMachine()));
                            break;
                            // Else is shit
                    }
                }
            }
        }
        private static IList<EvolutionChainJsonV2.EvolvesTo> GetChains(EvolutionChainJsonV2.EvolvesTo chain)
        {
            var list = new List<EvolutionChainJsonV2.EvolvesTo> { chain };
            foreach (var evolves_to in chain.evolves_to)
                list.AddRange(GetChains(evolves_to));
            return list;
        }


        public override string ToString() => $"{Name }"; //$"{Name,-15}";
    }

    public sealed class Monster : BaseMonsterInstance
    {
        public struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y) { X = x; Y = y; }
        }


        public ushort SecretID { get; }
        public uint PersonalityValue { get; }


        public string DisplayName => !string.IsNullOrWhiteSpace(CatchInfo.Nickname) ? CatchInfo.Nickname : StaticData.Name;


        public override Gender Gender => StaticData.MaleRatio < 0.0f ? Gender.Genderless : (PersonalityValue % 256 < (byte) (StaticData.MaleRatio * byte.MaxValue) ? Gender.Female : Gender.Male);

        public bool FirstAbility => (PersonalityValue / 65536) % 2 == 0;
        public override bool IsShiny => (PersonalityValue % 65536) < 16;
        public byte Characteristic => (byte)(PersonalityValue % 6);
        public override BaseAbility Ability => FirstAbility ? StaticData.Abilities.Ability_0 : StaticData.Abilities.Ability_1;

        public Point[] SpindaSpots => BitConverter.GetBytes(PersonalityValue).Select(b => new Point(b & 0x0F, b >> 4)).ToArray();
        public byte WurmplesEvolution => (byte) (PersonalityValue / 65536);


        public Monster(short species) : base(Cached<MonsterStaticData>.Get(species))
        {
            var random = new MersenneTwisterRandom();
            var thirtyBits = (uint) random.Next(1 << 30);
            var twoBits = (uint) random.Next(1 << 2);
            PersonalityValue = (thirtyBits << 2) | twoBits;

            Nature = GenerateNature();

            IV = new Stats(
                (short) random.Next(0, 31),
                (short) random.Next(0, 31),
                (short) random.Next(0, 31),
                (short) random.Next(0, 31),
                (short) random.Next(0, 31),
                (short) random.Next(0, 31));
            
            /*
            First Random Number:    x|xxxxx|xxxxx|xxxxx
                                    -|DefIV|AtkIV|HP IV

            Second Random Number:   x|xxxxx|xxxxx|xxxxx
                                    -|SpDIV|SpAIV|SpeIV
             */
        }
        public Monster(short species, ushort secretID, uint personalityValue, byte nature) : base(Cached<MonsterStaticData>.Get(species))
        {
            SecretID = secretID;
            PersonalityValue = personalityValue;

            Nature = nature;
        }
        public Monster(short species, Gender gender, bool isShiny, short ability, byte nature) : base(Cached<MonsterStaticData>.Get(species))
        {
            PersonalityValue = StaticData.Abilities.Contains(ability) ? GenerateRandom(gender, isShiny, ability) : 0;
            Nature = nature;
        }
        private uint GenerateRandom(Gender gender, bool isShiny, short ability)
        {
            int cycles = 0;

            Generate:
            if (cycles > 100)
                return 0;
            cycles++;

            var random = new MersenneTwisterRandom();
            var thirtyBits = (uint) random.Next(1 << 30);
            var twoBits = (uint) random.Next(1 << 2);
            var result = (thirtyBits << 2) | twoBits;

            Check:
            var cGender = StaticData.MaleRatio < 0.0f ? Gender.Genderless : (result % 256 < (byte) (StaticData.MaleRatio * byte.MaxValue) ? Gender.Male : Gender.Female);
            var cFirstAbility = (result / 65536 % 2) == 0;
            var cIsShiny = (result % 65536) < 16;

            if (gender != cGender || ((ability == StaticData.Abilities.Ability_0.StaticData.ID) != cFirstAbility) || isShiny != cIsShiny)
                goto Generate;

            return result;
        }
        private static byte GenerateNature() => (byte) new MersenneTwisterRandom().Next(25);



        public Monster(Monster father, Monster mother) : base(GetPreEvolution(mother.StaticData, father.StaticData))
        {
            
            InheritAttacks(father, mother, this);


            // -- Characteristic
            byte characteristic = InheritCharacteristic(father, mother, this);

            // -- Characteristic


        }
        private static IMonsterStaticData GetPreEvolution(IMonsterStaticData father, IMonsterStaticData mother)
        {
            // Baby/Ditto check.

            return mother;
        }
        private static bool CanPassDownNature(Monster monster) => monster.HeldItem.StaticData.Attributes.Any(att => att is ItemAttributePassDownNature);
        private static bool IsDitto(IMonsterStaticData monster) => false;
        private static void InheritAttacks(Monster father, Monster mother, Monster child)
        {
            var attacks = child.StaticData.LearnableAttacks.Where(attack => (attack.LearnCondition as AttackLearn.ByLevel)?.Level == 1).Select(la => la.Attack).ToList();
            var sharedAttacks = father.Moves.Intersect(mother.Moves).Select(attack => attack.StaticData);
            var learnableAttacks = child.StaticData.LearnableAttacks.Select(la => la.Attack).Select(la => sharedAttacks.Contains(la)).ToList();
        }
        private static void InheritAbility(Monster father, Monster mother, Monster child)
        {
            

        }
        private static byte InheritCharacteristic(Monster father, Monster mother, Monster child)
        {
            if (CanPassDownNature(father) && CanPassDownNature(mother))
            {
                switch (new Random().Next(0, 1))
                {
                    case 0:
                        return father.Characteristic;
                    case 1:
                        return mother.Characteristic;
                }
            }

            if (CanPassDownNature(father))
                return father.Characteristic;
            if (CanPassDownNature(mother))
                return mother.Characteristic;

            throw new Exception();
        }



        public Monster(DataItems dataItems) : this(GetID(dataItems), GetGender(dataItems), GetIsShiny(dataItems), GetAbility(dataItems), GetNature(dataItems))
        {
            var dict = dataItems.ToDictionary();


            Experience = int.Parse(dict["Experience"]);
            Friendship = byte.Parse(dict["Friendship"]);
            EggSteps = int.Parse(dict["EggSteps"]);
            CatchInfo = new CatchInfo()
            {
                Nickname = string.IsNullOrEmpty(dict["NickName"]) ? string.Empty : dict["NickName"],
                PokeballID = byte.Parse(dict["CatchBall"]),
                Method = dict["CatchMethod"],
                Location = dict["CatchLocation"],
                TrainerName = dict["CatchTrainer"],
                TrainerID = (ushort)int.Parse(dict["OT"]).BitsGet(0, 16) == ushort.MaxValue ? (ushort)int.Parse(dict["OT"]).BitsGet(16, 32) : (ushort)int.Parse(dict["OT"]).BitsGet(0, 16)
            };

            HeldItem = new Item(short.Parse(dict["Item"]));

            var move0 = dict["Attack1"].Split(',');
            var move1 = dict["Attack2"].Split(',');
            var move2 = dict["Attack3"].Split(',');
            var move3 = dict["Attack4"].Split(',');
            Moves = new List<BaseAttackInstance>();
            if (move0.Length != 1)
            {
                var dat = Cached<AttackStaticData>.Get(short.Parse(move0[0]));
                var ppUps = (byte) Math.Round((double) ((double) (byte.Parse(move0[1]) - dat.PP) / dat.PP / 0.2D));
                Moves.Add(new Attack(dat, byte.Parse(move0[2]), ppUps));
            }
            if (move1.Length != 1)
            {
                var dat = Cached<AttackStaticData>.Get(short.Parse(move1[0]));
                var ppUps = (byte) Math.Round((double) ((double) (byte.Parse(move1[1]) - dat.PP) / dat.PP / 0.2D));
                Moves.Add(new Attack(dat, byte.Parse(move1[2]), ppUps));
            }
            if (move2.Length != 1)
            {
                var dat = Cached<AttackStaticData>.Get(short.Parse(move2[0]));
                var ppUps = (byte) Math.Round((double) ((double) (byte.Parse(move2[1]) - dat.PP) / dat.PP / 0.2D));
                Moves.Add(new Attack(dat, byte.Parse(move2[2]), ppUps));
            }
            if (move3.Length != 1)
            {
                var dat = Cached<AttackStaticData>.Get(short.Parse(move3[0]));
                var ppUps = (byte) Math.Round((double) ((double) (byte.Parse(move3[1]) - dat.PP) / dat.PP / 0.2D));
                Moves.Add(new Attack(dat, byte.Parse(move3[2]), ppUps));
            }

            CurrentHP = short.Parse(dict["HP"]);

            var ev = dict["EVs"].Split(',');
            var ev0 = short.Parse(ev[0]);
            var ev1 = short.Parse(ev[1]);
            var ev2 = short.Parse(ev[2]);
            var ev3 = short.Parse(ev[3]);
            var ev4 = short.Parse(ev[4]);
            var ev5 = short.Parse(ev[5]);
            EV = new Stats(ev0, ev1, ev2, ev3, ev4, ev5);

            var iv = dict["IVs"].Split(',');
            var iv0 = short.Parse(iv[0]);
            var iv1 = short.Parse(iv[1]);
            var iv2 = short.Parse(iv[2]);
            var iv3 = short.Parse(iv[3]);
            var iv4 = short.Parse(iv[4]);
            var iv5 = short.Parse(iv[5]);
            IV = new Stats(iv0, iv1, iv2, iv3, iv4, iv5);
        }
        private static short GetID(DataItems dataItems)
        {
            var dict = dataItems.ToDictionary();
            return short.Parse(dict["Pokemon"]);
        }
        private static Gender GetGender(DataItems dataItems)
        {
            var dict = dataItems.ToDictionary();
            switch (int.Parse(dict["Gender"]))
            {
                case 0:
                    return Gender.Male;
                case 1:
                    return Gender.Female;
                case 2:
                    return Gender.Genderless;
            }
            return Gender.Genderless;
        }
        private static bool GetIsShiny(DataItems dataItems)
        {
            var dict = dataItems.ToDictionary();
            return int.Parse(dict["isShiny"]) != 0;
        }
        private static short GetAbility(DataItems dataItems)
        {
            var dict = dataItems.ToDictionary();
            return short.Parse(dict["Ability"]);

        }
        private static byte GetNature(DataItems dataItems)
        {
            var dict = dataItems.ToDictionary();
            return byte.Parse(dict["Nature"]);
        }


        public bool IsValid { get; private set; }
    }
}
