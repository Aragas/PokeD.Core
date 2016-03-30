using System;
using System.IO;
using System.Text;

using Aragas.Core.IO;
using Aragas.Core.Packets;
using Aragas.Core.Wrappers;

using PokeD.Core.Packets;

namespace PokeD.Core.IO
{
    public sealed class P3DStream : PacketStream
    {
        public override bool IsServer { get; }

        public override string Host => TCPClient.IP;
        public override ushort Port => TCPClient.Port;
        public override bool Connected => TCPClient != null && TCPClient.Connected;
        public override int DataAvailable => TCPClient?.DataAvailable ?? 0;


        private ITCPClient TCPClient { get; }

        protected override Stream BaseStream => TCPClient.GetStream();
        private byte[] _buffer;

        private StreamReader Reader { get; }


        public P3DStream(ITCPClient tcp, bool isServer = false)
        {
            TCPClient = tcp;
            IsServer = isServer;

            Reader = new StreamReader(BaseStream, Encoding.UTF8, true, 1024, true);
        }


        public override void Connect(string ip, ushort port) { TCPClient.Connect(ip, port); }
        public override void Disconnect() { TCPClient.Disconnect(); }


        // -- Anything 
        public override void Write<T>(T value = default(T)) { }

        private void ToBuffer(byte[] value)
        {
            if (_buffer != null)
            {
                Array.Resize(ref _buffer, _buffer.Length + value.Length);
                Array.Copy(value, 0, _buffer, _buffer.Length - value.Length, value.Length);
            }
            else
                _buffer = value;
        }


        public string ReadLine() => Reader.ReadLine();


        public void Send(byte[] buffer)
        {
            BaseStream.Write(buffer, 0, buffer.Length);
        }
        public byte[] Receive(int length)
        {
            var buffer = new byte[length];
            BaseStream.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        public override void SendPacket(Packet packet)
        {
            var p3dPacket = packet as P3DPacket;
            ToBuffer(Encoding.UTF8.GetBytes($"{p3dPacket.CreateData()}\r\n"));
            Purge();
        }

        private void Purge()
        {
            Send(_buffer);
            _buffer = null;
        }


        public override void Dispose()
        {
            Reader.Dispose();
        }
    }
}
