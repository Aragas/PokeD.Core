using System.IO;

using Aragas.Core.IO;

namespace PokeD.Core.IO
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class P3DDataReader : PacketDataReader
    {
        public override bool IsServer { get; }

        private readonly Stream _stream;
        

        public P3DDataReader(Stream stream, bool isServer = false)
        {
            _stream = stream;
            IsServer = isServer;
        }
        public P3DDataReader(byte[] data, bool isServer = false)
        {
            _stream = new MemoryStream(data);
            IsServer = isServer;
        }


        // -- Anything
        public override T Read<T>(T value = default(T), int length = 0) { return default(T); }


        public override int BytesLeft() => (int)(_stream.Length - _stream.Position);


        public override void Dispose()
        {
            _stream?.Dispose();
        }
    }
}
