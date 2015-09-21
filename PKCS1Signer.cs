using System;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

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

        public PKCS1Signer(AsymmetricKeyParameter rsaPublicKey)
        {
            RSAKeyPair = new AsymmetricCipherKeyPair(rsaPublicKey, null);
            OnlyPublic = true;
        }

        public PKCS1Signer(byte[] rsaPublicKey)
        {
            var key = (RsaKeyParameters)PublicKeyFactory.CreateKey(rsaPublicKey);
            RSAKeyPair = new AsymmetricCipherKeyPair(key, new RsaKeyParameters(true, BigInteger.One, BigInteger.One));
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
            if (OnlyPublic)
                throw new NotImplementedException("Not supported with only public key");

            var eng = new Pkcs1Encoding(new RsaEngine());
            eng.Init(false, RSAKeyPair.Private);
            return eng.ProcessBlock(data, 0, data.Length);
        }
    }
}
