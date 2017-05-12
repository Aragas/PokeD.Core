using NUnit.Framework;

using PokeD.Core.Data.PokeApi;

namespace PokeD.Core.Test
{
    [TestFixture]
    public class MonsterCachedTest
    {
        public MonsterCachedTest()
        {
            PokeApiV2.CacheType = PokeApiV2.CacheTypeEnum.None;
        }


        [Test]
        public void TestMonsterDataItems() { MonsterClass.MonsterDataItems(); }

        [Test]
        public void TestLoadStaticData() { MonsterClass.LoadStaticData(); }
    }
}
