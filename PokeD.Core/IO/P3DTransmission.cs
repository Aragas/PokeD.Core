using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aragas.Network.IO;

using PCLExt.Network;

using PokeD.Core.Packets.P3D;

namespace PokeD.Core.IO
{
    public class P3DTransmission : SocketPacketTransmission<P3DPacket, int, P3DSerializer, P3DDeserializer>
    {
        public P3DTransmission(ISocketClient socket, Type packetEnumType = null) : base(socket, packetEnumType) { }


        public override void SendPacket(P3DPacket packet)
        {
            Send(Encoding.UTF8.GetBytes($"{packet.CreateData()}\r\n"));
        }

        public override P3DPacket ReadPacket()
        {
            if (Socket.DataAvailable > 0)
            {
                var data = ReadLine();
                if (P3DPacket.TryParseID(data, out int id))
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
            while (symbol != -1)
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
                else if (nextSymbol == -1)
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