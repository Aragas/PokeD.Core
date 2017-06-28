using Aragas.Network.IO;

namespace PokeD.Core.IO
{
    public class P3DSerializer : PacketSerializer
    {
        public override byte[] GetBuffer() => new byte[0];

        // -- Anything 
        public override void Write<T>(T value = default(T), bool writeDefaultLength = true) { }

        public override void Dispose() { }
    }
}
