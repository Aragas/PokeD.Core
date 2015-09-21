using System;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.X509;

namespace PokeD.Core
{
    public sealed class PKCS1Signer
    {
        private AsymmetricCipherKeyPair RSAKeyPair { get; }
        private bool OnlyPublic { get; }

        public PKCS1Signer(AsymmetricCipherKeyPair rsaKeyPair)
        {
            RSAKeyPair = rsaKeyPair;
            OnlyPublic = false;
        }

        public PKCS1Signer(AsymmetricKeyParameter publicKey)
        {
            RSAKeyPair = new AsymmetricCipherKeyPair(publicKey, null);
            OnlyPublic = true;
        }

        public byte[] SignData(byte[] data)
        {
            var eng = new Pkcs1Encoding(new RsaEngine());
            eng.Init(true, RSAKeyPair.Public);
            return eng.ProcessBlock(data, 0, data.Length);
        }

        public byte[] DeSignData(byte[] data)
        {
            if(OnlyPublic)
                throw new NotImplementedException("Not supported with only public key");

            var eng = new Pkcs1Encoding(new RsaEngine());
            eng.Init(false, RSAKeyPair.Private);
            return eng.ProcessBlock(data, 0, data.Length);
        }
    }
}
