using System.IO;
using System.Net.Sockets;

namespace PokeD.Core.IO
{
    public class P3DSocketStream : NetworkStream
    {
        public P3DSocketStream(Socket socket) : base(socket)
        {
            socket.Blocking = false;
            socket.ReceiveTimeout = 500;
            socket.SendTimeout = 500;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (!Socket.Connected)
                return;

            try { base.Write(buffer, offset, count); }
            catch (IOException) { return; }
            catch (SocketException) { return; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (!Socket.Connected)
                return -1;

            try { return base.Read(buffer, offset, count); }
            catch (IOException) { return -1; }
            catch (SocketException) { return -1; }
        }

        public override int ReadByte()
        {
            var buffer = new byte[1];
            return Read(buffer, 0, 1) != -1 ? buffer[0] : -1;
        }
    }
}