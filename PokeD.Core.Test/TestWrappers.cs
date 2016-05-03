using System.IO;

using PCLExt.Network;

namespace PokeD.Core.Test
{
    public class TestITCPClient : ITCPClient
    {
        public MemoryStream Stream { get; } = new MemoryStream();

        public string IP => "NONE";
        public ushort Port => 0;
        public bool Connected => true;
        public int DataAvailable => (int) (Stream.Length - Stream.Position);


        public ITCPClient Connect(string ip, ushort port) { return this; }
        public ITCPClient Disconnect() { return this; }
        
        public void Write(byte[] buffer, int offset, int count) { Stream.Write(buffer, offset, count); }
        public int Read(byte[] buffer, int offset, int count) => Stream.Read(buffer, offset, count);


        public void Dispose() { }
    }
}
