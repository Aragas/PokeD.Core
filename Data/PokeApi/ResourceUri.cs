using System;
using System.Linq;

using Aragas.Core.Extensions;

namespace PokeD.Core.Data.PokeApi
{
    public class ResourceUri
    {
        public static string URL { private get; set; } = "";

        public enum ApiVersion { V1, V2 }
        public enum ApiType { Pokedex, Pokemon, PokemonSpecies, Type, Move, Ability, Egg, EggGroup, GrowthRate, Sprite, Language, Gender, Stat, Item, EvolutionTrigger }

        public string RawString { get; }
        public ApiVersion Version { get; }
        public ApiType Type { get; }
        public int Id { get; }

        public ResourceUri(string str, bool partial = false)
        {
            RawString = partial ? URL + str : str;
            
            var array = RawString.Split('/').Reverse().ToArray();

            Version = (ApiVersion) Enum.Parse(typeof (ApiVersion), array[3].RemoveWhitespace(), true);
            Type = (ApiType) Enum.Parse(typeof (ApiType), array[2].Replace("-", "").RemoveWhitespace(), true);
            Id = int.Parse(array[1]);
        }
        public ResourceUri(NamedAPIResource namedApiResource)
        {
            RawString = namedApiResource.url;

            var array = RawString.Split('/').Reverse().ToArray();

            Version = (ApiVersion) Enum.Parse(typeof (ApiVersion), array[3].RemoveWhitespace(), true);
            Type = (ApiType) Enum.Parse(typeof (ApiType), array[2].Replace("-", "").RemoveWhitespace(), true);
            Id = int.Parse(array[1]);
        }
    }
}