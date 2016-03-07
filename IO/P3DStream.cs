using System.Globalization;
using System.IO;
using System.Text;

using Aragas.Core.IO;
using Aragas.Core.Wrappers;

using PokeD.Core.Packets;

namespace PokeD.Core.IO
{
    public class P3DStream : StandardStream
    {
        private ITCPClient TCPClient { get; }
        protected  override Stream BaseStream =>  TCPClient.GetStream();

        private StreamReader Reader { get; }

        private static CultureInfo CultureInfo => CultureInfo.InvariantCulture;

        public P3DStream(ITCPClient tcp) : base(tcp)
        {
            TCPClient = tcp;
            Reader = new StreamReader(this, Encoding.UTF8, true, 1024, true);
        }

        public string ReadLine() { return Reader.ReadLine(); }

        private static string CreateData(ref P3DPacket packet)
        {
            var dataItems = packet.DataItems.ToArray();

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(P3DPacket.ProtocolVersion.ToString(CultureInfo));
            stringBuilder.Append("|");
            stringBuilder.Append(packet.ID.ToString());
            stringBuilder.Append("|");
            stringBuilder.Append(packet.Origin.ToString());

            if (dataItems.Length <= 0)
            {
                stringBuilder.Append("|0|");
                return stringBuilder.ToString();
            }

            stringBuilder.Append("|");
            stringBuilder.Append(dataItems.Length.ToString());
            stringBuilder.Append("|0|");

            var num = 0;
            for (var i = 0; i < dataItems.Length - 1; i++)
            {
                num += dataItems[i].Length;
                stringBuilder.Append(num);
                stringBuilder.Append("|");
            }

            foreach (var dataItem in dataItems)
                stringBuilder.Append(dataItem);

            return stringBuilder.ToString();
        }

        public void SendPacket(ref P3DPacket packet)
        {
            ToBuffer(Encoding.UTF8.GetBytes($"{CreateData(ref packet)}\r\n"));
            Purge();
        }

        protected override void Purge()
        {
            var array = Buffer.ToArray();

            Send(array);

            Buffer.SetLength(0);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Reader.Dispose();
        }
    }
}
