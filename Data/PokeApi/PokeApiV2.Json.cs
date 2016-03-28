using System.Collections.Generic;

namespace PokeD.Core.Data.PokeApi
{
    public interface PokeApiV2Json { }

    public class EvolutionChainsJsonV2 : PokeApiV2Json
    {
        public class EvolutionDetails
        {
            public object item { get; set; }
            public NamedAPIResource trigger { get; set; }
            public object gender { get; set; }
            public object held_item { get; set; }
            public object known_move { get; set; }
            public object known_move_type { get; set; }
            public object location { get; set; }
            public int min_level { get; set; }
            public object min_happiness { get; set; }
            public object min_beauty { get; set; }
            public object min_affection { get; set; }
            public bool needs_overworld_rain { get; set; }
            public object party_species { get; set; }
            public object party_type { get; set; }
            public object relative_physical_stats { get; set; }
            public string time_of_day { get; set; }
            public object trade_species { get; set; }
            public bool turn_upside_down { get; set; }
        }
        public class EvolvesTo
        {
            public bool is_baby { get; set; }
            public NamedAPIResource species { get; set; }
            public EvolutionDetails evolution_details { get; set; }
            public List<object> evolves_to { get; set; }
        }
        public class Chain
        {
            public bool is_baby { get; set; }
            public NamedAPIResource species { get; set; }
            public object evolution_details { get; set; }
            public List<EvolvesTo> evolves_to { get; set; }
        }


        public int id { get; set; }
        public NamedAPIResource baby_trigger_item { get; set; }
        public Chain chain { get; set; }
    }

    public class EvolutionTriggersJsonV2 : PokeApiV2Json
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Localization> names { get; set; }
        public List<NamedAPIResource> pokemon_species { get; set; }
    }

    public class ItemJsonV2 : PokeApiV2Json
    {
        public class EffectEntry
        {
            public string effect { get; set; }
            public string short_effect { get; set; }
            public NamedAPIResource language { get; set; }
        }
        public class FlavorTextEntry
        {
            public string text { get; set; }
            public NamedAPIResource version_group { get; set; }
            public NamedAPIResource language { get; set; }
        }
        public class GameIndice
        {
            public int game_index { get; set; }
            public NamedAPIResource generation { get; set; }
        }
        public class VersionDetail
        {
            public int rarity { get; set; }
            public NamedAPIResource version { get; set; }
        }
        public class HeldByPokemon
        {
            public NamedAPIResource pokemon { get; set; }
            public List<VersionDetail> version_details { get; set; }
        }
        public class BabyTriggerFor
        {
            public string url { get; set; }
        }


        public int id { get; set; }
        public string name { get; set; }
        public int cost { get; set; }
        public int? fling_power { get; set; }
        public NamedAPIResource fling_effect { get; set; }
        public List<NamedAPIResource> attributes { get; set; }
        public NamedAPIResource category { get; set; }
        public List<EffectEntry> effect_entries { get; set; }
        public List<FlavorTextEntry> flavor_text_entries { get; set; }
        public List<GameIndice> game_indices { get; set; }
        public List<Localization> names { get; set; }
        public List<HeldByPokemon> held_by_pokemon { get; set; }
        public BabyTriggerFor baby_trigger_for { get; set; }
    }

    public class PokemonSpeciesJsonV2 : PokeApiV2Json
    {
        public class PokedexNumber
        {
            public int entry_number { get; set; }
            public NamedAPIResource pokedex { get; set; }
        }
        public class EvolutionChain
        {
            public string url { get; set; }
        }
        public class PalParkEncounter
        {
            public int base_score { get; set; }
            public int rate { get; set; }
            public NamedAPIResource area { get; set; }
        }
        public class Genera
        {
            public string genus { get; set; }
            public NamedAPIResource language { get; set; }
        }
        public class Variety
        {
            public bool is_default { get; set; }
            public NamedAPIResource pokemon { get; set; }
        }


        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public int gender_rate { get; set; }
        public int capture_rate { get; set; }
        public int base_happiness { get; set; }
        public bool is_baby { get; set; }
        public int hatch_counter { get; set; }
        public bool has_gender_differences { get; set; }
        public bool forms_switchable { get; set; }
        public NamedAPIResource growth_rate { get; set; }
        public List<PokedexNumber> pokedex_numbers { get; set; }
        public List<NamedAPIResource> egg_groups { get; set; }
        public NamedAPIResource color { get; set; }
        public NamedAPIResource shape { get; set; }
        public object evolves_from_species { get; set; }
        public EvolutionChain evolution_chain { get; set; }
        public NamedAPIResource habitat { get; set; }
        public NamedAPIResource generation { get; set; }
        public List<Localization> names { get; set; }
        public List<PalParkEncounter> pal_park_encounters { get; set; }
        public List<object> form_descriptions { get; set; }
        public List<Genera> genera { get; set; }
        public List<Variety> varieties { get; set; }
    }

    public class GenderJsonV2 : PokeApiV2Json
    {
        public class PokemonSpeciesDetail
        {
            public int rate { get; set; }
            public NamedAPIResource pokemon_species { get; set; }
        }


        public int id { get; set; }
        public string name { get; set; }
        public List<PokemonSpeciesDetail> pokemon_species_details { get; set; }
        public List<NamedAPIResource> required_for_evolution { get; set; }
    }

    public class MoveJsonV2 : PokeApiV2Json
    {
        public class Normal
        {
            public List<NamedAPIResource> use_before { get; set; }
            public object use_after { get; set; }
        }
        public class Super
        {
            public object use_before { get; set; }
            public object use_after { get; set; }
        }
        public class ContestCombos
        {
            public Normal normal { get; set; }
            public Super super { get; set; }
        }
        public class ContestEffect
        {
            public string url { get; set; }
        }
        public class EffectEntry
        {
            public string effect { get; set; }
            public string short_effect { get; set; }
            public NamedAPIResource language { get; set; }
        }
        public class Meta
        {
            public NamedAPIResource ailment { get; set; }
            public NamedAPIResource category { get; set; }
            public object min_hits { get; set; }
            public object max_hits { get; set; }
            public object min_turns { get; set; }
            public object max_turns { get; set; }
            public int drain { get; set; }
            public int healing { get; set; }
            public int crit_rate { get; set; }
            public int ailment_chance { get; set; }
            public int flinch_chance { get; set; }
            public int stat_chance { get; set; }
        }
        public class SuperContestEffect
        {
            public string url { get; set; }
        }


        public int id { get; set; }
        public string name { get; set; }
        public int? accuracy { get; set; }
        public object effect_chance { get; set; }
        public int pp { get; set; }
        public int priority { get; set; }
        public int? power { get; set; }
        public ContestCombos contest_combos { get; set; }
        public NamedAPIResource contest_type { get; set; }
        public ContestEffect contest_effect { get; set; }
        public NamedAPIResource damage_class { get; set; }
        public List<EffectEntry> effect_entries { get; set; }
        public List<object> effect_changes { get; set; }
        public NamedAPIResource generation { get; set; }
        public Meta meta { get; set; }
        public List<Localization> names { get; set; }
        public List<object> past_values { get; set; }
        public List<object> stat_changes { get; set; }
        public SuperContestEffect super_contest_effect { get; set; }
        public NamedAPIResource target { get; set; }
        public NamedAPIResource type { get; set; }
    }
    
    public class EggGroupJsonV2 : PokeApiV2Json
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Localization> names { get; set; }
        public List<NamedAPIResource> pokemon_species { get; set; }
    }

    public class AbilitiesJsonV2 : PokeApiV2Json
    {
        public class EffectEntry
        {
            public string effect { get; set; }
            public string short_effect { get; set; }
            public NamedAPIResource language { get; set; }
        }
        public class EffectChange
        {
            public class EffectEntry
            {
                public string effect { get; set; }
                public NamedAPIResource language { get; set; }
            }


            public NamedAPIResource version_group { get; set; }
            public List<EffectEntry> effect_entries { get; set; }
        }
        public class FlavorTextEntry
        {
            public string flavor_text { get; set; }
            public NamedAPIResource language { get; set; }
            public NamedAPIResource version_group { get; set; }
        }
        public class Pokemon
        {
            public bool is_hidden { get; set; }
            public int slot { get; set; }
            public NamedAPIResource pokemon { get; set; }
        }


        public int id { get; set; }
        public string name { get; set; }
        public bool is_main_series { get; set; }
        public NamedAPIResource generation { get; set; }
        public List<Localization> names { get; set; }
        public List<EffectEntry> effect_entries { get; set; }
        public List<EffectChange> effect_changes { get; set; }
        public List<FlavorTextEntry> flavor_text_entries { get; set; }
        public List<Pokemon> pokemon { get; set; }
    }

    public class PokemonTypeJsonV2 : PokeApiV2Json
    {
        public class DamageRelations
        {
            public List<NamedAPIResource> no_damage_to { get; set; }
            public List<NamedAPIResource> half_damage_to { get; set; }
            public List<object> double_damage_to { get; set; }
            public List<NamedAPIResource> no_damage_from { get; set; }
            public List<object> half_damage_from { get; set; }
            public List<NamedAPIResource> double_damage_from { get; set; }
        }
        public class GameIndice
        {
            public int game_index { get; set; }
            public NamedAPIResource generation { get; set; }
        }
        public class Pokemon
        {
            public int slot { get; set; }
            public NamedAPIResource pokemon { get; set; }
        }


        public int id { get; set; }
        public string name { get; set; }
        public DamageRelations damage_relations { get; set; }
        public List<GameIndice> game_indices { get; set; }
        public NamedAPIResource generation { get; set; }
        public NamedAPIResource move_damage_class { get; set; }
        public List<Localization> names { get; set; }
        public List<Pokemon> pokemon { get; set; }
        public List<NamedAPIResource> moves { get; set; }
    }

    public class PokemonJsonV2 : PokeApiV2Json
    {
        public class Ability
        {
            public bool is_hidden { get; set; }
            public int slot { get; set; }
            public NamedAPIResource ability { get; set; }
        }
        public class GameIndice
        {
            public int game_index { get; set; }
            public NamedAPIResource version { get; set; }
        }
        public class HeldItem
        {
            public class VersionDetail
            {
                public int rarity { get; set; }
                public NamedAPIResource version { get; set; }
            }


            public NamedAPIResource item { get; set; }
            public List<VersionDetail> version_details { get; set; }
        }
        public class Move
        {
            public class VersionGroupDetail
            {
                public int level_learned_at { get; set; }
                public NamedAPIResource version_group { get; set; }
                public NamedAPIResource move_learn_method { get; set; }
            }


            public NamedAPIResource move { get; set; }
            public List<VersionGroupDetail> version_group_details { get; set; }
        }
        public class Stat
        {
            public int base_stat { get; set; }
            public int effort { get; set; }
            public NamedAPIResource stat { get; set; }
        }
        public class PokeType
        {
            public int slot { get; set; }
            public NamedAPIResource type { get; set; }
        }


        public int id { get; set; }
        public string name { get; set; }
        public int base_experience { get; set; }
        public int height { get; set; }
        public bool is_default { get; set; }
        public int order { get; set; }
        public int weight { get; set; }
        public List<Ability> abilities { get; set; }
        public List<NamedAPIResource> forms { get; set; }
        public List<GameIndice> game_indices { get; set; }
        public List<HeldItem> held_items { get; set; }
        public List<NamedAPIResource> location_area_encounters { get; set; }
        public List<Move> moves { get; set; }
        public NamedAPIResource species { get; set; }
        public List<Stat> stats { get; set; }
        public List<PokeType> types { get; set; }
    }
}
