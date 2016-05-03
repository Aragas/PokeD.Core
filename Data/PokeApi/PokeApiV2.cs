using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PCLExt.FileStorage;

using PokeD.Core.IO;

namespace PokeD.Core.Data.PokeApi
{
    public static class PokeApiV2
    {
        public static bool CacheData { get; set; } = false;


        #region Cache

        private static ConcurrentDictionary<int, PokemonJsonV2> CachePokemonJsonV2 { get; } = new ConcurrentDictionary<int, PokemonJsonV2>();
        private static ConcurrentDictionary<int, AbilitiesJsonV2> CacheAbilitiesJsonV2 { get; } = new ConcurrentDictionary<int, AbilitiesJsonV2>();
        private static ConcurrentDictionary<int, MoveJsonV2> CacheMoveJsonV2 { get; } = new ConcurrentDictionary<int, MoveJsonV2>();
        private static ConcurrentDictionary<int, PokemonTypeJsonV2> CachePokemonTypeJsonV2 { get; } = new ConcurrentDictionary<int, PokemonTypeJsonV2>();
        private static ConcurrentDictionary<int, EggGroupJsonV2> CacheEggGroupJsonV2 { get; } = new ConcurrentDictionary<int, EggGroupJsonV2>();
        private static ConcurrentDictionary<int, GenderJsonV2> CacheGenderJsonV2 { get; } = new ConcurrentDictionary<int, GenderJsonV2>();
        private static ConcurrentDictionary<int, PokemonSpeciesJsonV2> CachePokemonSpeciesJsonV2 { get; } = new ConcurrentDictionary<int, PokemonSpeciesJsonV2>();
        private static ConcurrentDictionary<int, ItemJsonV2> CacheItemJsonV2 { get; } = new ConcurrentDictionary<int, ItemJsonV2>();
        private static ConcurrentDictionary<int, EvolutionTriggersJsonV2> CacheEvolutionTriggersJsonV2 { get; } = new ConcurrentDictionary<int, EvolutionTriggersJsonV2>();


        private static async Task<T> CacheFunc<T>(ResourceUri uri, IDictionary<int, T> cache, Func<ResourceUri, Task<T>> func)
        {
            if (!CacheData)
                return await func(uri);
            

            var folder = await Storage.ContentFolder.CreateFolderAsync("Cache", CreationCollisionOption.OpenIfExists);
            var name = $"{uri.Type}_{uri.Id}.json";

 
            if (await folder.CheckExistsAsync(name) == ExistenceCheckResult.FileExists)
            {
                var file = await folder.GetFileAsync(name);
                var text = await file.ReadAllTextAsync();

                if (!cache.ContainsKey(uri.Id))
                    cache.Add(uri.Id, JsonConvert.DeserializeObject<T>(text));

                return JsonConvert.DeserializeObject<T>(text);
            }
            else
            {
                var obj = await func(uri);

                var file = await folder.CreateFileAsync(name, CreationCollisionOption.FailIfExists);
                await file.WriteAllTextAsync(JsonConvert.SerializeObject(obj));

                if (!cache.ContainsKey(uri.Id))
                    cache.Add(uri.Id, obj);

                return obj;
            }
        }
        private static async Task<T> Cache<T>(ResourceUri uri, IDictionary<int, T> cache, Func<ResourceUri, Task<T>> func) where T : PokeApiV2Json
        {
            return await CacheFunc(uri, cache, func);
        }
        private static async Task<IReadOnlyList<T>> Cache<T>(IEnumerable<ResourceUri> uris, IDictionary<int, T> cache, Func<ResourceUri, Task<T>> func) where T : PokeApiV2Json
        {
            var list = new List<T>();
            foreach (var uri in uris)
                list.Add(await CacheFunc(uri, cache, func));
            return list;
        }

        #endregion Cache

        #region IEnumerable temp fix

        public static async Task<IReadOnlyList<AbilitiesJsonV2>> GetAbilities(IEnumerable<ResourceUri> uris) => await GetAbilities(uris.ToArray());
        public static async Task<IReadOnlyList<MoveJsonV2>> GetMoves(IEnumerable<ResourceUri> uris) => await GetMoves(uris.ToArray());
        public static async Task<IReadOnlyList<PokemonTypeJsonV2>> GetTypes(IEnumerable<ResourceUri> uris) => await GetTypes(uris.ToArray());
        public static async Task<IReadOnlyList<EggGroupJsonV2>> GetEggGroups(IEnumerable<ResourceUri> uris) => await GetEggGroups(uris.ToArray());
        public static async Task<IReadOnlyList<GenderJsonV2>> GetGender(IEnumerable<ResourceUri> uris) => await GetGender(uris.ToArray());
        public static async Task<IReadOnlyList<ItemJsonV2>> GetItems(IEnumerable<ResourceUri> uris) => await GetItems(uris.ToArray());
        public static async Task<IReadOnlyList<EvolutionTriggersJsonV2>> GetEvolutionTriggers(IEnumerable<ResourceUri> uris) => await GetEvolutionTriggers(uris.ToArray());

        #endregion IEnumerable temp fix


        public static async Task<PokemonJsonV2> GetPokemon(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.Pokemon || uri.Version != ResourceUri.ApiVersion.V2)
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.Pokemon, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uri, CachePokemonJsonV2, GetNetworkJsonV2<PokemonJsonV2>);
        }
        public static async Task<IReadOnlyList<AbilitiesJsonV2>> GetAbilities(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Ability) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.Ability, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheAbilitiesJsonV2, GetNetworkJsonV2<AbilitiesJsonV2>);
        }
        public static async Task<IReadOnlyList<MoveJsonV2>> GetMoves(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Move) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.Move, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheMoveJsonV2, GetNetworkJsonV2<MoveJsonV2>);
        }
        public static async Task<IReadOnlyList<PokemonTypeJsonV2>> GetTypes(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Type) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.Type, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CachePokemonTypeJsonV2, GetNetworkJsonV2<PokemonTypeJsonV2>);
        }
        public static async Task<IReadOnlyList<EggGroupJsonV2>> GetEggGroups(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.EggGroup) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.EggGroup, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheEggGroupJsonV2, GetNetworkJsonV2<EggGroupJsonV2>);
        }
        public static async Task<IReadOnlyList<GenderJsonV2>> GetGender(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Gender) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.Gender.EvolutionTrigger, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheGenderJsonV2, GetNetworkJsonV2<GenderJsonV2>);
        }
        public static async Task<PokemonSpeciesJsonV2> GetPokemonSpecies(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.PokemonSpecies || uri.Version != ResourceUri.ApiVersion.V2)
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.PokemonSpecies, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uri, CachePokemonSpeciesJsonV2, GetNetworkJsonV2<PokemonSpeciesJsonV2>);
        }
        public static async Task<IReadOnlyList<ItemJsonV2>> GetItems(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Item) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.Item, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheItemJsonV2, GetNetworkJsonV2<ItemJsonV2>);
        }
        public static async Task<IReadOnlyList<EvolutionTriggersJsonV2>> GetEvolutionTriggers(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.EvolutionTrigger) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.EvolutionTrigger, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheEvolutionTriggersJsonV2, GetNetworkJsonV2<EvolutionTriggersJsonV2>);
        }


        private static HttpClient Client { get; } = new HttpClient();
        private static async Task<string> GetResponse(ResourceUri uri) => await Client.GetStringAsync(uri.RawString);
        private static async Task<T> GetNetworkJsonV2<T>(ResourceUri uri) where T : PokeApiV2Json => JsonConvert.DeserializeObject<T>(await GetResponse(uri));
    }
}