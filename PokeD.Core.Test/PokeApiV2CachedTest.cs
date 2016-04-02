using Aragas.Core.Wrappers;

using NUnit.Framework;

using PokeD.Core.Data.PokeApi;

namespace PokeD.Core.Test
{
    [TestFixture]
    public class PokeApiV2CachedTest
    {
        public PokeApiV2CachedTest()
        {
            AppDomainWrapper.Instance = new TestIAppDomain();
            FileSystemWrapper.Instance = new TestIFileSystem();

            PokeApiV2.CacheData = true;
        }


        [Test]
        public void TestGetPokemon() { PokeApiV2Class.GetPokemon(); }

        [Test]
        public void TestGetPokemonSpecies() { PokeApiV2Class.GetPokemonSpecies(); }

        [Test]
        public void TestGetTypes() { PokeApiV2Class.GetTypes(); }

        [Test]
        public void TestGetGender() { PokeApiV2Class.GetGender(); }

        [Test]
        public void TestGetAbilities() { PokeApiV2Class.GetAbilities(); }

        [Test]
        public void TestGetEggGroups() { PokeApiV2Class.GetEggGroups(); }

        [Test]
        public void TestGetItems() { PokeApiV2Class.GetItems(); }

        [Test]
        public void TestGetMoves() { PokeApiV2Class.GetMoves(); }

        [Test]
        public void TestGetEvolutionTriggers() { PokeApiV2Class.GetEvolutionTriggers(); }
    }
}
