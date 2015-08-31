using System;
using System.Threading.Tasks;

namespace PokeD.Core.IO
{
    public interface IAesStreamAsync
    {
        Task<Int32> ReadAsync(byte[] buffer, int offset, int count);

        Task WriteAsync(byte[] buffer, int offset, int count);
    }

    /// <summary>
    /// Object that implements AES.
    /// </summary>
    public interface IAesStream : IAesStreamAsync, IDisposable
    {
        int Read(byte[] buffer, int offset, int count);

        void Write(byte[] buffer, int offset, int count);
    }
}