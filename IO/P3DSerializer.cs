using Aragas.Network.IO;

namespace PokeD.Core.IO
{
    public class P3DSerializer : PacketSerializer
    {
        private byte[] _buffer;

        public override byte[] GetBuffer() => _buffer;

        // -- Anything 
        public override void Write<T>(T value = default(T), bool writeDefaultLength = true) { }

        public override void Dispose() { }
    }
}
