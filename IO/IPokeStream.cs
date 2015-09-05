using System;
using System.Numerics;
using System.Threading.Tasks;

using PokeD.Core.Data;
using PokeD.Core.Interfaces;

namespace PokeD.Core.IO
{
    public interface IPokeStreamWrite
    {
        void WriteString(String value, Int32 length = 0);

        void WriteVarInt(VarInt value);

        void WriteBoolean(Boolean value);

        void WriteSByte(SByte value);
        void WriteByte(Byte value);

        void WriteShort(Int16 value);
        void WriteUShort(UInt16 value);

        void WriteInt(Int32 value);
        void WriteUInt(UInt32 value);

        void WriteLong(Int64 value);
        void WriteULong(UInt64 value);

        void WriteBigInteger(BigInteger value);
        void WriteUBigInteger(BigInteger value);

        void WriteDouble(Double value);

        void WriteFloat(Single value);


        void WriteStringArray(String[] value);

        void WriteVarIntArray(Int32[] value);

        void WriteIntArray(Int32[] value);

        void WriteByteArray(Byte[] value);
    }

    public interface IPokeStreamRead
    {
        Byte ReadByte();

        VarInt ReadVarInt();

        Byte[] ReadByteArray(Int32 value);

        String ReadLine();
    }

    public interface IPokeStreamConnection
    {
        void Connect(String ip, UInt16 port);
        void Disconnect();

        void SendPacket(ref IPacket packet);
    }

    public interface IPokeStreamConnectionStatus
    {
        Boolean Connected { get; }
        Int32 DataAvailable { get; }

        Boolean EncryptionEnabled { get; }
        UInt32 CompressionThreshold { get; }

        void InitializeEncryption(Byte[] key);

        void SetCompression(UInt32 threshold);
    }

    /// <summary>
    /// Object that reads VarInt (or Byte) and ByteArray for handling Data later 
    /// and writes any data from packet to user-defined object, that will interact with Minecraft Server.
    /// </summary>
    public interface IPokeStream : IPokeStreamWrite, IPokeStreamRead, IPokeStreamConnection, IPokeStreamConnectionStatus, IDisposable
    {

    }
}
