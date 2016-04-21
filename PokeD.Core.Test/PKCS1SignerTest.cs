using System;

using Aragas.Core;

using NUnit.Framework;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Security;

namespace PokeD.Core.Test
{
    [TestFixture]
    public class PKCS1SignerTest
    {
        private const int RsaKeySize = 4096;
        private static AsymmetricCipherKeyPair GenerateKeyPair()
        {
            var secureRandom = new SecureRandom(new DigestRandomGenerator(new Sha512Digest()));
            var keyGenerationParameters = new KeyGenerationParameters(secureRandom, RsaKeySize);

            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            return keyPairGenerator.GenerateKeyPair();
        }


        [Test]
        public void Test()
        {
            var length = 256;

            var expected = new byte[length];
            var actual = new byte[length];

            new Random().NextBytes(expected);

            var signer = new PKCS1Signer(GenerateKeyPair());
            actual = signer.SignData(expected);
            actual = signer.DeSignData(actual);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
