using System.IO;

namespace PokeD.Core.IO
{
    public sealed partial class P3DStream : Stream
    {
        public override bool CanRead => _reader.BaseStream.CanRead;
        public override bool CanSeek => _reader.BaseStream.CanSeek;
        public override bool CanWrite => _reader.BaseStream.CanWrite;
        public override long Length => _reader.BaseStream.Length;
        public override long Position { get { return _reader.BaseStream.Position; } set { _reader.BaseStream.Position = value; } }

        private readonly StreamReader _reader;

        public string ReadLine()
        {
            return _reader.ReadLine();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _reader.BaseStream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _reader.BaseStream.Write(buffer, offset, count);
        }

        public override void Flush()
        {
            _reader.BaseStream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _reader.BaseStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _reader.BaseStream.SetLength(value);
        }
    }
}
