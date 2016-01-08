using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

using Aragas.Core.Wrappers;

using Newtonsoft.Json;

using PCLStorage;

using PokeD.Core.Extensions;

namespace PokeD.Core.Data.PokeD
{
    public class ResourceUri
    {
        public enum ApiVersion { V1, V2 }
        public enum ApiType { Pokedex, Pokemon, Type, Move, Ability, Egg, Description, Sprite, Game }

        public string RawString { get; }
        public ApiVersion Version { get; }
        public ApiType Type { get; }
        public int Id { get; }

        public ResourceUri(string str)
        {
            RawString = str;

            var array = RawString.Split('/');

            Version = (ApiVersion) Enum.Parse(typeof (ApiVersion), array[2].RemoveWhitespace(), true);
            Type = (ApiType) Enum.Parse(typeof (ApiType), array[3].RemoveWhitespace(), true);
            Id = int.Parse(array[4]);
        }
    }

    public static class PokeApi
    {
        public static bool UseNetwork { get; set; } = false;

        public static PokemonJson GetPokemon(ResourceUri uri)
        {
            if ( uri.Type != ResourceUri.ApiType.Pokemon || uri.Version != ResourceUri.ApiVersion.V1)
                throw new Exception();

            return UseNetwork ? GetPokemonNetwork(uri) : GetPokemonLocal(uri.Id);
        }
        public static List<AbilitiesJson> GetAbilities(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Ability) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V1))
                throw new Exception();

            return UseNetwork ? GetAbilitiesNetwork(uris) : GetAbilitiesLocal(uris.Select(uri => uri.Id).ToArray());
        }
        public static List<MoveJson> GetMoves(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Move) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V1))
                throw new Exception();

            return UseNetwork ? GetMovesNetwork(uris) : GetMovesLocal(uris.Select(uri => uri.Id).ToArray());
        }
        public static List<PokemonTypeJson> GetTypes(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Type) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V1))
                throw new Exception();

            return UseNetwork ? GetTypesNetwork(uris) : GetTypesLocal(uris.Select(uri => uri.Id).ToArray());
        }
        public static List<EggGroupJson> GetEggGroups(params ResourceUri[] uris)
        {
            if (uris.Any(uri => uri.Type != ResourceUri.ApiType.Egg) || uris.Any(uri => uri.Version != ResourceUri.ApiVersion.V1))
                throw new Exception();

            return UseNetwork ? GetEggGroupsNetwork(uris) : GetEggGroupsLocal(uris.Select(uri => uri.Id).ToArray());
        }

        private static PokemonJson GetPokemonNetwork(ResourceUri uri)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync(new Uri($"http://pokeapi.co{uri.RawString}")).Result;

            return JsonConvert.DeserializeObject<PokemonJson>(response);
        }
        private static List<AbilitiesJson> GetAbilitiesNetwork(params ResourceUri[] uris)
        {
            var client = new HttpClient();

            return uris.Select(uri => client.GetStringAsync(new Uri($"http://pokeapi.co{uri.RawString}")).Result).Select(JsonConvert.DeserializeObject<AbilitiesJson>).ToList();
        }
        private static List<MoveJson> GetMovesNetwork(params ResourceUri[] uris)
        {
            var client = new HttpClient();

            return uris.Select(uri => client.GetStringAsync(new Uri($"http://pokeapi.co{uri.RawString}")).Result).Select(JsonConvert.DeserializeObject<MoveJson>).ToList();
        }
        private static List<PokemonTypeJson> GetTypesNetwork(params ResourceUri[] uris)
        {
            var client = new HttpClient();

            return uris.Select(uri => client.GetStringAsync(new Uri($"http://pokeapi.co{uri.RawString}")).Result).Select(JsonConvert.DeserializeObject<PokemonTypeJson>).ToList();
        }
        private static List<EggGroupJson> GetEggGroupsNetwork(params ResourceUri[] uris)
        {
            var client = new HttpClient();

            return uris.Select(uri => client.GetStringAsync(new Uri($"http://pokeapi.co{uri.RawString}")).Result).Select(JsonConvert.DeserializeObject<EggGroupJson>).ToList();
        }

        private static PokemonJson GetPokemonLocal(int id)
        {
            using (var pstream = FileSystemWrapper.DatabaseFolder.GetFolderAsync("Pokemons").Result.GetFileAsync($"{id}.json").Result.OpenAsync(FileAccess.Read).Result)
            using (var preader = new StreamReader(pstream))
                return JsonConvert.DeserializeObject<PokemonJson>(preader.ReadToEnd());
        }
        private static List<AbilitiesJson> GetAbilitiesLocal(params int[] ids)
        {
            var abilities = new List<AbilitiesJson>();

            foreach (var id in ids)
            {
                using (var astream = FileSystemWrapper.DatabaseFolder.GetFolderAsync("Abilities").Result.GetFileAsync($"{id}.json").Result.OpenAsync(FileAccess.Read).Result)
                using (var areader = new StreamReader(astream))
                    abilities.Add(JsonConvert.DeserializeObject<AbilitiesJson>(areader.ReadToEnd()));
            }
            
            return abilities;
        }
        private static List<MoveJson> GetMovesLocal(params int[] ids)
        {
            var moves = new List<MoveJson>();

            foreach (var id in ids)
            {
                using (var mstream = FileSystemWrapper.DatabaseFolder.GetFolderAsync("Moves").Result.GetFileAsync($"{id}.json").Result.OpenAsync(FileAccess.Read).Result)
                using (var mreader = new StreamReader(mstream))
                    moves.Add(JsonConvert.DeserializeObject<MoveJson>(mreader.ReadToEnd()));
            }
            
            return moves;
        }
        private static List<PokemonTypeJson> GetTypesLocal(params int[] ids)
        {
            var types = new List<PokemonTypeJson>();

            foreach (var id in ids)
            {
                using (var tstream = FileSystemWrapper.DatabaseFolder.GetFolderAsync("Types").Result.GetFileAsync($"{id}.json").Result.OpenAsync(FileAccess.Read).Result)
                using (var treader = new StreamReader(tstream))
                    types.Add(JsonConvert.DeserializeObject<PokemonTypeJson>(treader.ReadToEnd()));
            }
            
            return types;
        }
        private static List<EggGroupJson> GetEggGroupsLocal(params int[] ids)
        {
            var eggGroups = new List<EggGroupJson>();

            foreach (var id in ids)
            {
                using (var estream = FileSystemWrapper.DatabaseFolder.GetFolderAsync("Egg Groups").Result.GetFileAsync($"{id}.json").Result.OpenAsync(FileAccess.Read).Result)
                using (var ereader = new StreamReader(estream))
                    eggGroups.Add(JsonConvert.DeserializeObject<EggGroupJson>(ereader.ReadToEnd()));
            }

            return eggGroups;
        }
    }

}