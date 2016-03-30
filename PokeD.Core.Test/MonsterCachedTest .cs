using Aragas.Core.Wrappers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PokeD.Core.Data.PokeApi;

namespace PokeD.Core.Test
{
    [TestClass]
    public class MonsterCachedTest
    {
        public MonsterCachedTest()
        {
            AppDomainWrapper.Instance = new TestIAppDomain();
            FileSystemWrapper.Instance = new TestIFileSystem();

            PokeApiV2.CacheData = true;
        }


        [TestMethod]
        public void TestMonsterDataItems() { MonsterClass.MonsterDataItems(); }

        [TestMethod]
        public void TestLoadStaticData() { MonsterClass.LoadStaticData(); }
    }
}
