using System.IO;

using Aragas.Network.IO;

namespace PokeD.Core.IO
{
    public sealed class P3DDeserializer : PacketDeserialiser
    {
        public P3DDeserializer() : base(Stream.Null) { }

        public override T Read<T>(T value = default(T), int length = 0) => default(T);
    }
}
