using System;

namespace PokeD.Core.IO
{
    /// <summary>
    /// Object that implements AES.
    /// </summary>
    public interface IAesStream : IDisposable
    {
        int Read(byte[] buffer, int offset, int count);

        void Write(byte[] buffer, int offset, int count);
    }
}