using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using Newtonsoft.Json;

namespace PokeD.Core.Data.PokeD
{
    public static class PokeApiV2
    {
        public static bool UseNetwork { get; set; } = true;

        public static PokemonJsonV2 GetPokemon(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.Pokemon || uri.Version != ResourceUri.ApiVersion.V2)
                throw new Exception();

            return GetPokemonNetwork(uri);
        }
        public static List<AbilitiesJsonV2> GetAbilities(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Ability) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new Exception();

            return GetAbilitiesNetwork(uris);
        }
        public static List<MoveJsonV2> GetMoves(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Move) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new Exception();

            return GetMovesNetwork(uris);
        }
        public static List<PokemonTypeJsonV2> GetTypes(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Type) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new Exception();

            return GetTypesNetwork(uris);
        }
        public static List<EggGroupJsonV2> GetEggGroups(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.EggGroup) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new Exception();

            return GetEggGroupsNetwork(uris);
        }
        public static GenderJsonV2 GetGender(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.Gender || uri.Version != ResourceUri.ApiVersion.V2)
                throw new Exception();

            return GetGenderNetwork(uri);
        }
        public static PokemonSpeciesJsonV2 GetPokemonSpecies(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.PokemonSpecies || uri.Version != ResourceUri.ApiVersion.V2)
                throw new Exception();

            return GetPokemonSpeciesNetwork(uri);
        }
        public static List<ItemJsonV2> GetItems(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Item) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new Exception();

            return GetItemsNetwork(uris);
        }
        public static EvolutionTriggersJsonV2 GetEvolutionTriggers(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.EvolutionTrigger || uri.Version != ResourceUri.ApiVersion.V2)
                throw new Exception();

            return GetEvolutionTriggersNetwork(uri);
        }

        private static PokemonJsonV2 GetPokemonNetwork(ResourceUri uri)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync(new Uri(uri.RawString)).Result;

            return JsonConvert.DeserializeObject<PokemonJsonV2>(response);
        }
        private static List<AbilitiesJsonV2> GetAbilitiesNetwork(params ResourceUri[] uris)
        {
            var client = new HttpClient();

            return uris.Select(uri => client.GetStringAsync(new Uri(uri.RawString)).Result).Select(JsonConvert.DeserializeObject<AbilitiesJsonV2>).ToList();
        }
        private static List<MoveJsonV2> GetMovesNetwork(params ResourceUri[] uris)
        {
            var client = new HttpClient();

            return uris.Select(uri => client.GetStringAsync(new Uri(uri.RawString)).Result).Select(JsonConvert.DeserializeObject<MoveJsonV2>).ToList();
        }
        private static List<PokemonTypeJsonV2> GetTypesNetwork(params ResourceUri[] uris)
        {
            var client = new HttpClient();

            return uris.Select(uri => client.GetStringAsync(new Uri(uri.RawString)).Result).Select(JsonConvert.DeserializeObject<PokemonTypeJsonV2>).ToList();
        }
        private static List<EggGroupJsonV2> GetEggGroupsNetwork(params ResourceUri[] uris)
        {
            var client = new HttpClient();

            return uris.Select(uri => client.GetStringAsync(new Uri(uri.RawString)).Result).Select(JsonConvert.DeserializeObject<EggGroupJsonV2>).ToList();
        }
        private static GenderJsonV2 GetGenderNetwork(ResourceUri uri)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync(new Uri(uri.RawString)).Result;

            return JsonConvert.DeserializeObject<GenderJsonV2>(response);
        }
        private static PokemonSpeciesJsonV2 GetPokemonSpeciesNetwork(ResourceUri uri)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync(new Uri(uri.RawString)).Result;

            return JsonConvert.DeserializeObject<PokemonSpeciesJsonV2>(response);
        }
        private static List<ItemJsonV2> GetItemsNetwork(params ResourceUri[] uris)
        {
            var client = new HttpClient();

            return uris.Select(uri => client.GetStringAsync(new Uri(uri.RawString)).Result).Select(JsonConvert.DeserializeObject<ItemJsonV2>).ToList();
        }
        private static EvolutionTriggersJsonV2 GetEvolutionTriggersNetwork(ResourceUri uri)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync(new Uri(uri.RawString)).Result;

            return JsonConvert.DeserializeObject<EvolutionTriggersJsonV2>(response);
        }
    }

}