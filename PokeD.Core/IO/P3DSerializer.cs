using Aragas.Network.IO;

namespace PokeD.Core.IO
{
    public class P3DSerializer : StreamSerializer
    {
        public override byte[] GetBuffer() => new byte[0];

        // -- Anything 
        public override void Write<T>(in T value = default, bool writeDefaultLength = true) { }

        public override void Dispose() { }
    }
}
