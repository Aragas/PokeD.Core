using Aragas.Network.IO;

using System;

namespace PokeD.Core.IO
{
    public class P3DSerializer : StreamSerializer
    {
        public override byte[] GetBuffer() => Array.Empty<byte>();

        // -- Anything 
        public override void Write<T>(in T value = default, bool writeDefaultLength = true) { }

        public override void Dispose() { }
    }
}