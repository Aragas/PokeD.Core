using System;
using System.Globalization;
using System.IO;
using System.Text;

using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;
using Aragas.Core.Wrappers;

using PokeD.Core.Packets;

namespace PokeD.Core.IO
{
    public sealed partial class P3DStream : IPacketStream
    {
        public bool IsServer => false;

        public bool Connected => _tcp != null && _tcp.Connected;
        public int DataAvailable => _tcp?.DataAvailable ?? 0;

        public bool EncryptionEnabled => false;

        private static CultureInfo CultureInfo => CultureInfo.InvariantCulture;

        private readonly ITCPClient _tcp;


        public P3DStream(ITCPClient tcp)
        {
            _tcp = tcp;
            _reader = new StreamReader(_tcp.GetStream());
        }


        public void InitializeEncryption(byte[] key)
        {
            throw new NotSupportedException();
        }


        public void Connect(string ip, ushort port)
        {
            _tcp.Connect(ip, port);
        }
        public void Disconnect()
        {
            _tcp.Disconnect();
        }


        #region Write

        // -- String
        public void Write(string value, int length = 0)
        {
            throw new NotSupportedException();
        }

        // -- VarInt
        public void Write(VarInt value)
        {
            throw new NotSupportedException();
        }

        // -- Boolean
        public void Write(bool value)
        {
            throw new NotSupportedException();
        }

        // -- SByte & Byte
        public void Write(sbyte value)
        {
            throw new NotSupportedException();
        }
        public void Write(byte value)
        {
            throw new NotSupportedException();
        }

        // -- Short & UShort
        public void Write(short value)
        {
            throw new NotSupportedException();
        }
        public void Write(ushort value)
        {
            throw new NotSupportedException();
        }

        // -- Int & UInt
        public void Write(int value)
        {
            throw new NotSupportedException();
        }
        public void Write(uint value)
        {
            throw new NotSupportedException();
        }

        // -- Long & ULong
        public void Write(long value)
        {
            throw new NotSupportedException();
        }
        public void Write(ulong value)
        {
            throw new NotSupportedException();
        }

        // -- Float
        public void Write(float value)
        {
            throw new NotSupportedException();
        }

        // -- Double
        public void Write(double value)
        {
            throw new NotSupportedException();
        }

        // -- StringArray
        public void Write(string[] value)
        {
            throw new NotSupportedException();
        }

        // -- VarIntArray
        public void Write(int[] value)
        {
            throw new NotSupportedException();
        }

        // -- IntArray
        public void Write(VarInt[] value)
        {
            throw new NotSupportedException();
        }

        // -- ByteArray
        public void Write(byte[] value)
        {
            throw new NotSupportedException();
        }

        #endregion Write


        #region Read

        public byte ReadByte()
        {
            throw new NotSupportedException();
        }

        public VarInt ReadVarInt()
        {
            throw new NotSupportedException();
        }

        public byte[] ReadByteArray(int length)
        {
            throw new NotSupportedException();
        }

        #endregion Read


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

        public void SendPacket(ref ProtobufPacket packet)
        {
            throw new NotImplementedException();
        }
        public void SendPacket(ref P3DPacket packet)
        {
            var str = CreateData(ref packet);
            var array = Encoding.UTF8.GetBytes(str + "\r\n");
            _tcp.WriteByteArray(array);
        }


        void IDisposable.Dispose()
        {
            if (Connected)
                _tcp.Disconnect();

            _tcp?.Dispose();
        }
    }
}
