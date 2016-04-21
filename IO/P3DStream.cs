using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


        public P3DStream(ITCPClient tcp, bool isServer = false)
        {
            TCPClient = tcp;
            IsServer = isServer;
        }


        public override void Connect(string ip, ushort port) { TCPClient.Connect(ip, port); }
        public override void Disconnect() { TCPClient.Disconnect(); }


        // -- Anything 
        public override void Write<T>(T value = default(T), bool writeDefaultLength = true) { }

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


        public override byte[] GetBuffer() => _buffer;

        private StringBuilder StringBuilder { get; } = new StringBuilder();
        private IEnumerable<string> ReadLineEnumerable()
        {
            var symbol = ReadByte();
            while (symbol != -1)
            {
                /*
                var nextSymbol = 0;
                if (symbol == 13 && DataAvailable == 0)
                {
                    var line = StringBuilder.ToString();
                    StringBuilder.Clear();

                    yield return line;
                }
                else if ((nextSymbol = ReadByte()) == 10 && symbol == 13)
                {
                    var line = StringBuilder.ToString();
                    StringBuilder.Clear();

                    yield return line;
                }
                else if(nextSymbol == -1)
                    yield return string.Empty;
                else
                {
                    StringBuilder.Append((char)symbol);
                    symbol = nextSymbol;
                }
                */


                var nextSymbol = ReadByte();
                if(nextSymbol == -1)
                    yield return string.Empty;

                if (symbol == 13 && nextSymbol == 10)
                {
                    var line = StringBuilder.ToString();
                    StringBuilder.Clear();

                    yield return line;
                }
                else
                {
                    StringBuilder.Append((char) symbol);
                    symbol = nextSymbol;
                }
            }
            yield return string.Empty;
        }
        public string ReadLine() => ReadLineEnumerable().First();


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


        public override void Dispose() { }
    }
}
