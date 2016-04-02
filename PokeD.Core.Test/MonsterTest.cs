using NUnit.Framework;

namespace PokeD.Core.Test
{
    [TestFixture]
    public class MonsterTest
    {
        [Test]
        public void TestMonsterDataItems() { MonsterClass.MonsterDataItems(); }

        [Test]
        public void TestLoadStaticData() { MonsterClass.LoadStaticData(); }
    }
}
