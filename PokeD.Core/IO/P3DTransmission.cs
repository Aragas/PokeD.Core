using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

using Aragas.Network.IO;

using PCLExt.Network;

using PokeD.Core.Packets.P3D;

namespace PokeD.Core.IO
{
    public class BetterSocketStream : NetworkStream
    {
        public BetterSocketStream(Socket socket) : base(socket) { }


        public override void Write(byte[] buffer, int offset, int count)
        {
            try { base.Write(buffer, offset, count); }
            catch (IOException) { return; }
            catch (SocketException) { return; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
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


    public class P3DTransmission : SocketPacketTransmission<P3DPacket, int, P3DSerializer, P3DDeserializer>
    {
        public P3DTransmission(ISocketClient socketClient, Type packetEnumType = null) : base(socketClient, packetEnumType)
        {
            var socket = socketClient.GetType().GetProperty("Socket", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(socketClient) as Socket;
            typeof(SocketPacketTransmission<P3DPacket, int, P3DSerializer, P3DDeserializer>).GetField("<SocketStream>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, new BetterSocketStream(socket));
        }


        public override void SendPacket(P3DPacket packet)
        {
            Send(Encoding.UTF8.GetBytes($"{packet.CreateData()}\r\n"));
        }

        public override P3DPacket ReadPacket()
        {
            if (Socket.DataAvailable > 0)
            {
                var data = ReadLine();
                if (P3DPacket.TryParseID(data, out var id))
                {
                    var packet = Factory.Create(id);
                    if (packet?.TryParseData(data) == true)
                        return packet;
                }
            }

            return null;
        }


        private StringBuilder StringBuilder { get; } = new StringBuilder();
        private IEnumerable<string> ReadLineEnumerable()
        {
            var symbol = (char) SocketStream.ReadByte();
            while (symbol != char.MaxValue) // -1 will be char.MaxValue
            {
                char nextSymbol;
                if (symbol == '\r' && Socket.DataAvailable == 0)
                {
                    var line = StringBuilder.ToString();
                    StringBuilder.Clear();

                    yield return line;
                }
                else if ((nextSymbol = (char) SocketStream.ReadByte()) == '\n' && symbol == '\r')
                {
                    var line = StringBuilder.ToString();
                    StringBuilder.Clear();

                    yield return line;
                }
                else if (nextSymbol == char.MaxValue)
                    yield return string.Empty;
                else
                {
                    StringBuilder.Append(symbol);
                    symbol = nextSymbol;
                }

                
                /*
                var nextSymbol = (char) ReadByte();
                if(nextSymbol == -1)
                    yield return string.Empty;
                if (symbol == '\r' && nextSymbol == '\n')
                {
                    var line = StringBuilder.ToString();
                    StringBuilder.Clear();
                    yield return line;
                }
                else
                {
                    StringBuilder.Append(symbol);
                    symbol = nextSymbol;
                }
                */
            }
            yield return string.Empty;
        }
        public string ReadLine() => ReadLineEnumerable().First();
    }
}