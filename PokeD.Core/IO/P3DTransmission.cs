using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

using Aragas.Network.IO;

using PokeD.Core.Packets.P3D;

namespace PokeD.Core.IO
{
    public class P3DTransmission : SocketPacketTransmission<P3DPacket, int, P3DSerializer, P3DDeserializer>
    {
        public P3DTransmission(Socket socket, Type packetEnumType = null) : base(socket, new P3DSocketStream(socket), packetEnumType) { }


        public override void SendPacket(P3DPacket packet)
        {
            Send(Encoding.UTF8.GetBytes($"{packet.CreateData()}\r\n"));
        }

        public override P3DPacket ReadPacket()
        {
            var data = ReadLine(); // Is blocking

            if (P3DPacket.TryParseID(data, out var id))
            {
                var packet = Factory.Create(id);
                if (packet?.TryParseData(data) == true)
                    return packet;
            }

            return null;
        }

        public bool TryReadPacket(out P3DPacket packet)
        {
            var data = ReadLine(); // Is blocking

            if (P3DPacket.TryParseID(data, out var id))
            {
                packet = Factory.Create(id);
                return packet?.TryParseData(data) == true;
            }

            packet = null;
            return false;
        }


        private StringBuilder StringBuilder { get; } = new StringBuilder();
        private IEnumerable<string> ReadLineEnumerable()
        {
            int @byte = SocketStream.ReadByte();
            char symbol = (char) @byte;
            while (@byte != -1)
            {
                int nextByte;
                char nextSymbol = char.MinValue;
                if (symbol == '\r' && Socket.Available == 0)
                {
                    var line = StringBuilder.ToString();
                    StringBuilder.Clear();

                    yield return line;
                }
                else if ((nextByte = SocketStream.ReadByte()) != -1 && (nextSymbol = (char) nextByte) == '\n' && symbol == '\r')
                {
                    var line = StringBuilder.ToString();
                    StringBuilder.Clear();

                    yield return line;
                }
                else if (nextByte == -1)
                    yield return string.Empty;
                else
                {
                    StringBuilder.Append(symbol);
                    symbol = nextSymbol;
                }
            }
            yield return string.Empty;
        }
        public string ReadLine() => ReadLineEnumerable().First();
    }
}