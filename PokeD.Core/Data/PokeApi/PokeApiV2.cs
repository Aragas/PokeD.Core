using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PCLExt.FileStorage;
using PCLExt.FileStorage.Extensions;

using PokeD.Core.Storage.Files;
using PokeD.Core.Storage.Folders;

namespace PokeD.Core.Data.PokeApi
{
    public static class PokeApiV2
    {
        public enum CacheTypeEnum
        {
            /// <summary>
            /// Slow, but uses small amount of RAM
            /// </summary>
            Zip,

            /// <summary>
            /// Fast, but expect x4 of the whole app RAM usage
            /// </summary>
            ZipInMemory,
            

            Standard,
            StandardCompressed,

            /// <summary>
            /// Uses the specified website for data access.
            /// </summary>
            None,
        }

        private static CacheTypeEnum _cacheType;
        public static CacheTypeEnum CacheType
        {
            get => _cacheType;
            set
            {
                _cacheType = value;

                if ((_cacheType == CacheTypeEnum.Zip || _cacheType == CacheTypeEnum.ZipInMemory) && CacheFile == null)
                    CacheFile = new PokeApiFile(_cacheType == CacheTypeEnum.ZipInMemory);
            }
        }



        #region Cache

        private static PokeApiFile CacheFile { get; set; }

        private static ConcurrentDictionary<int, PokemonJsonV2> CachePokemonJsonV2 { get; } = new ConcurrentDictionary<int, PokemonJsonV2>();
        private static ConcurrentDictionary<int, AbilitiesJsonV2> CacheAbilitiesJsonV2 { get; } = new ConcurrentDictionary<int, AbilitiesJsonV2>();
        private static ConcurrentDictionary<int, MoveJsonV2> CacheMoveJsonV2 { get; } = new ConcurrentDictionary<int, MoveJsonV2>();
        private static ConcurrentDictionary<int, PokemonTypeJsonV2> CachePokemonTypeJsonV2 { get; } = new ConcurrentDictionary<int, PokemonTypeJsonV2>();
        private static ConcurrentDictionary<int, EggGroupJsonV2> CacheEggGroupJsonV2 { get; } = new ConcurrentDictionary<int, EggGroupJsonV2>();
        private static ConcurrentDictionary<int, GenderJsonV2> CacheGenderJsonV2 { get; } = new ConcurrentDictionary<int, GenderJsonV2>();
        private static ConcurrentDictionary<int, PokemonSpeciesJsonV2> CachePokemonSpeciesJsonV2 { get; } = new ConcurrentDictionary<int, PokemonSpeciesJsonV2>();
        private static ConcurrentDictionary<int, ItemJsonV2> CacheItemJsonV2 { get; } = new ConcurrentDictionary<int, ItemJsonV2>();
        private static ConcurrentDictionary<int, EvolutionTriggersJsonV2> CacheEvolutionTriggersJsonV2 { get; } = new ConcurrentDictionary<int, EvolutionTriggersJsonV2>();
        private static ConcurrentDictionary<int, PokemonHabitatJsonV2> CachePokemonHabitatJsonV2 { get; } = new ConcurrentDictionary<int, PokemonHabitatJsonV2>();
        private static ConcurrentDictionary<int, PokemonShapeV2Json> CachePokemonShapeV2Json { get; } = new ConcurrentDictionary<int, PokemonShapeV2Json>();
        private static ConcurrentDictionary<int, EvolutionChainJsonV2> CacheEvolutionChainJsonV2 { get; } = new ConcurrentDictionary<int, EvolutionChainJsonV2>();
        private static ConcurrentDictionary<int, PokemonColorV2Json> CachePokemonColorV2Json { get; } = new ConcurrentDictionary<int, PokemonColorV2Json>();
        private static ConcurrentDictionary<int, ItemAttributeV2Json> CacheItemAttributeV2Json { get; } = new ConcurrentDictionary<int, ItemAttributeV2Json>();
        

        private static async Task<T> CacheFunc<T>(ResourceUri uri, IDictionary<int, T> cache, Func<ResourceUri, Task<T>> func) where T: PokeApiV2Json
        {
            switch (CacheType)
            {
                case CacheTypeEnum.None:
                    return await func(uri);

                case CacheTypeEnum.Standard:
                case CacheTypeEnum.StandardCompressed:
                    if (cache.ContainsKey(uri.ID))
                        return cache[uri.ID];

                    var name = $"{uri.Type}_{uri.ID}.json";
                    var folder = new PokeApiCacheFolder().CreateFolder(uri.Type.ToString(), CreationCollisionOption.OpenIfExists);
                    if (await folder.CheckExistsAsync(name) == ExistenceCheckResult.FileExists)
                    {
                        var file = await folder.GetFileAsync(name);
                        var text = CacheType == CacheTypeEnum.Standard ? await file.ReadAllTextAsync() : DecompressString(await file.ReadAllTextAsync());

                        if (!cache.ContainsKey(uri.ID))
                            cache.Add(uri.ID, JsonConvert.DeserializeObject<T>(text));

                        return JsonConvert.DeserializeObject<T>(text);
                    }
                    else
                    {
                        var obj = await func(uri);

                        var file = await folder.CreateFileAsync(name, CreationCollisionOption.FailIfExists);
                        await file.WriteAllTextAsync(CacheType == CacheTypeEnum.Standard ? JsonConvert.SerializeObject(obj) : CompressString(JsonConvert.SerializeObject(obj)));

                        if (!cache.ContainsKey(uri.ID))
                            cache.Add(uri.ID, obj);

                        return obj;
                    }

                case CacheTypeEnum.Zip:
                case CacheTypeEnum.ZipInMemory:
                    return CacheFile.Contains(uri) ? (T) CacheFile.Get(uri) : null;

                default:
                    return null;
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

        private static string CompressString(string uncompressedString)
        {
            var compressedStream = new MemoryStream();
            var uncompressedStream = new MemoryStream(Encoding.UTF8.GetBytes(uncompressedString));

            using (var compressorStream = new DeflateStream(compressedStream, CompressionMode.Compress, true))
                uncompressedStream.CopyTo(compressorStream);

            var array = compressedStream.ToArray();
            return Convert.ToBase64String(array, 0, array.Length);
        }
        private static string DecompressString(string compressedString)
        {
            var decompressedStream = new MemoryStream();
            var compressedStream = new MemoryStream(Convert.FromBase64String(compressedString));

            using (var decompressorStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
                decompressorStream.CopyTo(decompressedStream);

            var array = decompressedStream.ToArray();
            return Encoding.UTF8.GetString(array, 0, array.Length);
        }

        #endregion Cache

        #region IEnumerable temp fix

        public static async Task<IReadOnlyList<AbilitiesJsonV2>> GetAbilitiesAsync(IEnumerable<ResourceUri> uris) => await GetAbilitiesAsync(uris.ToArray());
        public static async Task<IReadOnlyList<MoveJsonV2>> GetMovesAsync(IEnumerable<ResourceUri> uris) => await GetMovesAsync(uris.ToArray());
        public static async Task<IReadOnlyList<PokemonTypeJsonV2>> GetTypesAsync(IEnumerable<ResourceUri> uris) => await GetTypesAsync(uris.ToArray());
        public static async Task<IReadOnlyList<EggGroupJsonV2>> GetEggGroupsAsync(IEnumerable<ResourceUri> uris) => await GetEggGroupsAsync(uris.ToArray());
        public static async Task<IReadOnlyList<GenderJsonV2>> GetGenderAsync(IEnumerable<ResourceUri> uris) => await GetGenderAsync(uris.ToArray());
        public static async Task<IReadOnlyList<ItemJsonV2>> GetItemsAsync(IEnumerable<ResourceUri> uris) => await GetItemsAsync(uris.ToArray());
        public static async Task<IReadOnlyList<EvolutionTriggersJsonV2>> GetEvolutionTriggersAsync(IEnumerable<ResourceUri> uris) => await GetEvolutionTriggersAsync(uris.ToArray());

        #endregion IEnumerable temp fix


        public static async Task<PokemonJsonV2> GetPokemonAsync(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.Pokemon || uri.Version != ResourceUri.ApiVersion.V2)
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.Pokemon, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uri, CachePokemonJsonV2, GetNetworkJsonV2<PokemonJsonV2>);
        }
        public static async Task<AbilitiesJsonV2> GetAbilityAsync(ResourceUri uri) => (await GetAbilitiesAsync(uri)).First();
        public static async Task<IReadOnlyList<AbilitiesJsonV2>> GetAbilitiesAsync(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Ability) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.Ability, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheAbilitiesJsonV2, GetNetworkJsonV2<AbilitiesJsonV2>);
        }
        public static async Task<MoveJsonV2> GetMoveAsync(ResourceUri uri) => (await GetMovesAsync(uri)).First();
        public static async Task<IReadOnlyList<MoveJsonV2>> GetMovesAsync(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Move) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.Move, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheMoveJsonV2, GetNetworkJsonV2<MoveJsonV2>);
        }
        public static async Task<PokemonTypeJsonV2> GetTypeAsync(ResourceUri uri) => (await GetTypesAsync(uri)).First();
        public static async Task<IReadOnlyList<PokemonTypeJsonV2>> GetTypesAsync(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Type) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.Type, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CachePokemonTypeJsonV2, GetNetworkJsonV2<PokemonTypeJsonV2>);
        }
        public static async Task<EggGroupJsonV2> GetEggGroupAsync(ResourceUri uri) => (await GetEggGroupsAsync(uri)).First();
        public static async Task<IReadOnlyList<EggGroupJsonV2>> GetEggGroupsAsync(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.EggGroup) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.EggGroup, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheEggGroupJsonV2, GetNetworkJsonV2<EggGroupJsonV2>);
        }
        public static async Task<IReadOnlyList<GenderJsonV2>> GetGenderAsync(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Gender) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.Gender.EvolutionTrigger, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheGenderJsonV2, GetNetworkJsonV2<GenderJsonV2>);
        }
        public static async Task<PokemonSpeciesJsonV2> GetPokemonSpeciesAsync(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.PokemonSpecies || uri.Version != ResourceUri.ApiVersion.V2)
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.PokemonSpecies, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uri, CachePokemonSpeciesJsonV2, GetNetworkJsonV2<PokemonSpeciesJsonV2>);
        }
        public static async Task<ItemJsonV2> GetItemAsync(ResourceUri uri) => (await GetItemsAsync(uri)).First();
        public static async Task<IReadOnlyList<ItemJsonV2>> GetItemsAsync(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Item) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.Item, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheItemJsonV2, GetNetworkJsonV2<ItemJsonV2>);
        }
        public static async Task<IReadOnlyList<EvolutionTriggersJsonV2>> GetEvolutionTriggersAsync(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.EvolutionTrigger) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.EvolutionTrigger, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheEvolutionTriggersJsonV2, GetNetworkJsonV2<EvolutionTriggersJsonV2>);
        }
        public static async Task<PokemonHabitatJsonV2> GetHabitatAsync(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.PokemonHabitat || uri.Version != ResourceUri.ApiVersion.V2)
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.PokemonHabitat, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uri, CachePokemonHabitatJsonV2, GetNetworkJsonV2<PokemonHabitatJsonV2>);
        }
        public static async Task<PokemonShapeV2Json> GetShapeAsync(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.PokemonShape || uri.Version != ResourceUri.ApiVersion.V2)
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.PokemonShape, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uri, CachePokemonShapeV2Json, GetNetworkJsonV2<PokemonShapeV2Json>);
        }
        public static async Task<EvolutionChainJsonV2> GetEvolutionChainAsync(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.EvolutionChain || uri.Version != ResourceUri.ApiVersion.V2)
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.EvolutionChain, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uri, CacheEvolutionChainJsonV2, GetNetworkJsonV2<EvolutionChainJsonV2>);
        }
        public static async Task<PokemonColorV2Json> GetPokemonColorAsync(ResourceUri uri)
        {
            if (uri.Type != ResourceUri.ApiType.PokemonColor || uri.Version != ResourceUri.ApiVersion.V2)
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.PokemonColor, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uri, CachePokemonColorV2Json, GetNetworkJsonV2<PokemonColorV2Json>);
        }
        public static async Task<ItemAttributeV2Json> GetItemAttributeAsync(ResourceUri uri) => (await GetItemAttributesAsync(uri)).First();
        public static async Task<IReadOnlyList<ItemAttributeV2Json>> GetItemAttributesAsync(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.ItemAttribute) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V2))
                throw new PokeApiException("ResourceUri Type not correct. Should be ResourceUri.ApiType.ItemAttribute, or request is not ResourceUri.ApiVersion.V2");

            return await Cache(uris, CacheItemAttributeV2Json, GetNetworkJsonV2<ItemAttributeV2Json>);
        }


        private static HttpClient Client { get; } = new HttpClient();
        private static async Task<string> GetResponse(ResourceUri uri) => await Client.GetStringAsync(uri.RawString);

        private static async Task<T> GetNetworkJsonV2<T>(ResourceUri uri) where T : PokeApiV2Json => JsonConvert.DeserializeObject<T>(await GetResponse(uri));
    }
}