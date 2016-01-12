using System;
using System.Linq;
using PokeD.Core.Extensions;

namespace PokeD.Core.Data.PokeD
{
    public class Localization
    {
        public string name { get; set; }
        public NamedAPIResource language { get; set; }
    }
    public class NamedAPIResource
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public enum Languages
    {
        Japanese        = 1,
        OfficialRoomaji = 2,
        Korean          = 3,
        Chinese         = 4,
        French          = 5,
        German          = 6,
        Spanish         = 7,
        Italian         = 8,
        English         = 9,
        Czech           = 10,
    }


    public class ResourceUri
    {
        public static string URL { get; set; } = "";

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
