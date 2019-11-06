using System.IO;

using Aragas.Network.IO;

namespace PokeD.Core.IO
{
    public sealed class P3DDeserializer : StreamDeserializer
    {
        public P3DDeserializer() : base(Stream.Null) { }

        public override T Read<T>(in T value = default, int length = 0) => default;
    }
}