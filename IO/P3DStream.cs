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

        private readonly INetworkTCPClient _tcp;


        public P3DStream(INetworkTCPClient tcp)
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
        void IPacketStreamWrite.Write(string value, int length = 0)
        {
            throw new NotSupportedException();
        }

        // -- VarInt
        void IPacketStreamWrite.Write(VarInt value)
        {
            throw new NotSupportedException();
        }

        // -- Boolean
        void IPacketStreamWrite.Write(bool value)
        {
            throw new NotSupportedException();
        }

        // -- SByte & Byte
        void IPacketStreamWrite.Write(sbyte value)
        {
            throw new NotSupportedException();
        }
        void IPacketStreamWrite.Write(byte value)
        {
            throw new NotSupportedException();
        }

        // -- Short & UShort
        void IPacketStreamWrite.Write(short value)
        {
            throw new NotSupportedException();
        }
        void IPacketStreamWrite.Write(ushort value)
        {
            throw new NotSupportedException();
        }

        // -- Int & UInt
        void IPacketStreamWrite.Write(int value)
        {
            throw new NotSupportedException();
        }
        void IPacketStreamWrite.Write(uint value)
        {
            throw new NotSupportedException();
        }

        // -- Long & ULong
        void IPacketStreamWrite.Write(long value)
        {
            throw new NotSupportedException();
        }
        void IPacketStreamWrite.Write(ulong value)
        {
            throw new NotSupportedException();
        }

        // -- Float
        void IPacketStreamWrite.Write(float value)
        {
            throw new NotSupportedException();
        }

        // -- Double
        void IPacketStreamWrite.Write(double value)
        {
            throw new NotSupportedException();
        }

        // -- StringArray
        void IPacketStreamWrite.Write(string[] value)
        {
            throw new NotSupportedException();
        }

        // -- VarIntArray
        void IPacketStreamWrite.Write(int[] value)
        {
            throw new NotSupportedException();
        }

        // -- IntArray
        void IPacketStreamWrite.Write(VarInt[] value)
        {
            throw new NotSupportedException();
        }

        // -- ByteArray
        void IPacketStreamWrite.Write(byte[] value)
        {
            throw new NotSupportedException();
        }

        #endregion Write


        #region Read

        byte IPacketStreamRead.ReadByte()
        {
            throw new NotSupportedException();
        }

        VarInt IPacketStreamRead.ReadVarInt()
        {
            throw new NotSupportedException();
        }

        byte[] IPacketStreamRead.ReadByteArray(int length)
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
            _tcp.Send(array, 0, array.Length);
        }


        void IDisposable.Dispose()
        {
            if (Connected)
                _tcp.Disconnect();

            _tcp?.Dispose();
        }
    }
}
