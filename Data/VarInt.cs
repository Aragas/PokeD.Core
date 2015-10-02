﻿using System.Collections.Generic;

namespace PokeD.Core.Data
{
    public class VarInt
    {
        private readonly int _value;

        public VarInt(int value)
        {
            _value = value;
        }

        public static implicit operator VarInt(int value)
        {
            return new VarInt(value);
        }

        public static implicit operator int (VarInt value)
        {
            return value._value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public byte[] InByteArray()
        {
            uint value = (uint) _value;

            var bytes = new List<byte>();
            while (true)
            {
                if ((value & 0xFFFFFF80u) == 0)
                {
                    bytes.Add((byte) value);
                    break;
                }
                bytes.Add((byte) (value & 0x7F | 0x80));
                value >>= 7;
            }

            return bytes.ToArray();
        }
    }
}
