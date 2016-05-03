using System;
using System.Linq;

using PokeD.Core.Extensions;

namespace PokeD.Core.Data.PokeApi
{
    public class ResourceUri
    {
        public static string URL { get; set; } = "http://pokeapi.co/";

        public enum ApiVersion
        {
            V1,
            V2
        }

        public enum ApiType
        {
            Berry,
            BerryFirmness,
            BerryFlavor,
            ContestType,
            ContestEffect,
            SuperContestEffect,
            EncounterMethod,
            EncounterCondition,
            EncounterConditionValue,
            EvolutionChain,
            EvolutionTrigger,
            Generation,
            Pokedex,
            Version,
            VersionGroup,
            Item,
            ItemAttribute,
            ItemCategory,
            ItemFlingEffect,
            ItemPocket,
            Move,
            MoveAilment,
            MoveBattleStyle,
            MoveCategory,
            MoveDamageClass,
            MoveLearnMethod,
            MoveTarget,
            Location,
            LocationArea,
            PalParkArea,
            Region,
            Ability,
            Characteristic,
            EggGroup,
            Gender,
            GrowthRate,
            Nature,
            PokeathlonStat,
            Pokemon,
            PokemonColor,
            PokemonForm,
            PokemonHabitat,
            PokemonShape,
            PokemonSpecies,
            Stat,
            Type,
            Language
        }

        public string RawString { get; }
        public ApiVersion Version { get; }
        public ApiType Type { get; }
        public int Id { get; }

        public ResourceUri(string str, bool partial = false)
        {
            RawString = partial ? URL + str : str;
            
            var array = RawString.Split('/').Where(x => !string.IsNullOrEmpty(x)).Reverse().ToArray();

            Version = (ApiVersion) Enum.Parse(typeof (ApiVersion), array[2].RemoveWhitespace(), true);
            Type = (ApiType) Enum.Parse(typeof (ApiType), array[1].Replace("-", "").RemoveWhitespace(), true);
            Id = int.Parse(array[0]);
        }
        public ResourceUri(NamedAPIResource namedApiResource)
        {
            RawString = namedApiResource.url;

            var array = RawString.Split('/').Where(x => !string.IsNullOrEmpty(x)).Reverse().ToArray();

            Version = (ApiVersion) Enum.Parse(typeof (ApiVersion), array[2].RemoveWhitespace(), true);
            Type = (ApiType) Enum.Parse(typeof (ApiType), array[1].Replace("-", "").RemoveWhitespace(), true);
            Id = int.Parse(array[0]);
        }
    }
}