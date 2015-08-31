﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PokeD.Core.IO;

namespace PokeD.Core.Data
{
    /// <summary>
    /// Represents the location of an object in 3D space (double).
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector3 : IEquatable<Vector3>
    {
        public readonly float X;
        public readonly float Y;
        public readonly float Z;

        public Vector3(float value)
        {
            X = Y = Z = value;
        }

        public Vector3(float yaw, float pitch)
        {
            var yawRadians = ToRadians(yaw);
            var pitchRadians = ToRadians(pitch);

            var sinYaw = Math.Sin(yawRadians);
            var cosYaw = Math.Cos(yawRadians);
            var sinPitch = Math.Sin(pitchRadians);
            var cosPitch = Math.Cos(pitchRadians);

            X = (float)(-cosPitch * sinYaw);
            Y = (float)(-sinPitch);
            Z = (float)(cosPitch * cosYaw);

            //X = (float) (-Math.Cos(pitch) * Math.Sin(yaw));
            //Y = (float) -Math.Sin(pitch);
            //Z = (float) (Math.Cos(pitch) * Math.Cos(yaw));
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(double x, double y, double z)
        {
            X = (float)x;
            Y = (float)y;
            Z = (float)z;
        }

        public Vector3(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public static Vector3 FromFixedPoint(int x, int y, int z)
        {
            return new Vector3(
                x / 32.0f,
                y / 32.0f,
                z / 32.0f
            );
        }

        public static Vector3 FromPokeString(string str)
        {
            var data = str.Split('|');

            if (data.Length != 3)
                return Vector3.Zero;

            return new Vector3(
                float.Parse(data[0].Replace(",", "."), CultureInfo.InvariantCulture) * 1000 / 1000,
                float.Parse(data[1].Replace(",", "."), CultureInfo.InvariantCulture) * 1000 / 1000,
                float.Parse(data[2].Replace(",", "."), CultureInfo.InvariantCulture) * 1000 / 1000);
        }

        public string ToPokeString()
        {
            var data = new StringBuilder();
            data.Append((X * 1000 / 1000).ToString(CultureInfo.InvariantCulture).Replace(".", ","));
            data.Append("|");
            data.Append((Y * 1000 / 1000).ToString(CultureInfo.InvariantCulture).Replace(".", ","));
            data.Append("|");
            data.Append((Z * 1000 / 1000).ToString(CultureInfo.InvariantCulture).Replace(".", ","));

            return data.ToString();
        }

        #region Network

        public static Vector3 FromReaderByte(IPokeDataReader reader)
        {
            return new Vector3(
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte()
            );
        }

        public static Vector3 FromReaderSByte(IPokeDataReader reader)
        {
            return new Vector3(
                reader.ReadSByte(),
                reader.ReadSByte(),
                reader.ReadSByte()
            );
        }

        public static Vector3 FromReaderShort(IPokeDataReader reader)
        {
            return new Vector3(
                reader.ReadShort(),
                reader.ReadShort(),
                reader.ReadShort()
            );
        }

        public static Vector3 FromReaderFloat(IPokeDataReader reader)
        {
            return new Vector3(
                reader.ReadFloat(),
                reader.ReadFloat(),
                reader.ReadFloat()
            );
        }

        public static Vector3 FromReaderDouble(IPokeDataReader reader)
        {
            return new Vector3(
                reader.ReadDouble(),
                reader.ReadDouble(),
                reader.ReadDouble()
            );
        }

        public static Vector3 FromReaderSByteFixedPoint(IPokeDataReader reader)
        {
            return new Vector3(
                reader.ReadSByte() / 32.0f,
                reader.ReadSByte() / 32.0f,
                reader.ReadSByte() / 32.0f
            );
        }

        public static Vector3 FromReaderIntFixedPoint(IPokeDataReader reader)
        {
            return new Vector3(
                reader.ReadInt() / 32.0f,
                reader.ReadInt() / 32.0f,
                reader.ReadInt() / 32.0f
            );
        }


        public void ToStreamByte(IPokeStream stream)
        {
            stream.WriteByte((byte)X);
            stream.WriteByte((byte)Y);
            stream.WriteByte((byte)Z);
        }

        public void ToStreamSByte(IPokeStream stream)
        {
            stream.WriteSByte((sbyte)X);
            stream.WriteSByte((sbyte)Y);
            stream.WriteSByte((sbyte)Z);
        }

        public void ToStreamShort(IPokeStream stream)
        {
            stream.WriteShort((short)X);
            stream.WriteShort((short)Y);
            stream.WriteShort((short)Z);
        }

        public void ToStreamFloat(IPokeStream stream)
        {
            stream.WriteFloat(X);
            stream.WriteFloat(Y);
            stream.WriteFloat(Z);
        }

        public void ToStreamDouble(IPokeStream stream)
        {
            stream.WriteDouble(X);
            stream.WriteDouble(Y);
            stream.WriteDouble(Z);
        }
        // TODO: Check that
        public void ToStreamSByteFixedPoint(IPokeStream stream)
        {
            stream.WriteSByte((sbyte)(X * 32));
            stream.WriteSByte((sbyte)(Y * 32));
            stream.WriteSByte((sbyte)(Z * 32));
        }
        // TODO: Check that
        public void ToStreamIntFixedPoint(IPokeStream stream)
        {
            stream.WriteInt((int)X * 32);
            stream.WriteInt((int)Y * 32);
            stream.WriteInt((int)Z * 32);
        }

        #endregion

        /// <summary>
        /// Converts this Vector3 to a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
        }

        #region Math

        /// <summary>
        /// Truncates the decimal component of each part of this Vector3.
        /// </summary>
        public Vector3 Floor()
        {
            return new Vector3(Math.Floor(X), Math.Floor(Y), Math.Floor(Z));
        }


        /// <summary>
        /// Calculates the distance between two Vector3 objects.
        /// </summary>
        public double DistanceTo(Vector3 other)
        {
            return Math.Sqrt(Square(other.X - X) +
                             Square(other.Y - Y) +
                             Square(other.Z - Z));
        }

        /// <summary>
        /// Calculates the square of a num.
        /// </summary>
        private static double Square(double num)
        {
            return num * num;
        }

        /// <summary>
        /// Finds the distance of this vector from Vector3.Zero
        /// </summary>
        public double Distance()
        {
            return DistanceTo(Zero);
        }

        public static Vector3 Min(Vector3 value1, Vector3 value2)
        {
            return new Vector3(
                Math.Min(value1.X, value2.X),
                Math.Min(value1.Y, value2.Y),
                Math.Min(value1.Z, value2.Z)
                );
        }

        public static Vector3 Max(Vector3 value1, Vector3 value2)
        {
            return new Vector3(
                Math.Max(value1.X, value2.X),
                Math.Max(value1.Y, value2.Y),
                Math.Max(value1.Z, value2.Z)
                );
        }

        public static Vector3 Delta(Vector3 firstLocation, Vector3 secondLocation)
        {
            return new Vector3(
                firstLocation.X - secondLocation.X,
                firstLocation.Y - secondLocation.Y,
                firstLocation.Z - secondLocation.Z
                );
        }


        public static float ToYaw(Vector3 position, Vector3 look)
        {
            var delta = Delta(look, position);

            return (float)Math.Atan2(delta.Z, delta.X);
        }

        public static Vector3 Yaw(Vector3 look, float angle)
        {
            var x = (look.Z * -Math.Sin(angle)) + (look.X * Math.Cos(angle));
            var y = look.Y;
            var z = (look.Z * Math.Cos(angle)) - (look.X * -Math.Sin(angle));

            return new Vector3(x, y, z);
        }

        public Vector3 Yaw(float angle)
        {
            return Yaw(this, angle);
        }


        public static float ToPitch(Vector3 position, Vector3 look)
        {
            var delta = Delta(look, position);

            return (float)(Math.Atan2(Math.Sqrt(Square(delta.Z) + Square(delta.X)), delta.Y) + Math.PI);
        }

        public static Vector3 Pitch(Vector3 look, float angle)
        {
            var x = look.X;
            var y = (look.Y * Math.Cos(angle)) - (look.Z * Math.Sin(angle));
            var z = (look.Y * Math.Sin(angle)) + (look.Z * Math.Cos(angle));

            return new Vector3(x, y, z);
        }

        public Vector3 Pitch(float angle)
        {
            return Pitch(this, angle);
        }


        public static Vector3 Roll(Vector3 look, float angle)
        {
            var x = (look.X * Math.Cos(angle)) - (look.Y * Math.Sin(angle));
            var y = (look.X * Math.Sin(angle)) + (look.Y * Math.Cos(angle));
            var z = look.Z;

            return new Vector3(x, y, z);
        }

        public Vector3 Roll(float angle)
        {
            return Roll(this, angle);
        }


        public static float ToRadians(float val)
        {
            return (float)(val * Math.PI / 180.0f);
        }


        #endregion

        #region Operators

        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !a.Equals(b);
        }

        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return a.Equals(b);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.X, -a.Y, -a.Z);
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }

        public static Vector3 operator %(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X % b.X, a.Y % b.Y, a.Z % b.Z);
        }

        public static Vector3 operator +(Vector3 a, double b)
        {
            return new Vector3(a.X + b, a.Y + b, a.Z + b);
        }

        public static Vector3 operator -(Vector3 a, double b)
        {
            return new Vector3(a.X - b, a.Y - b, a.Z - b);
        }

        public static Vector3 operator *(Vector3 a, double b)
        {
            return new Vector3(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector3 operator /(Vector3 a, double b)
        {
            return new Vector3(a.X / b, a.Y / b, a.Z / b);
        }

        public static Vector3 operator %(Vector3 a, double b)
        {
            return new Vector3(a.X % b, a.Y % b, a.Y % b);
        }

        public static Vector3 operator +(double a, Vector3 b)
        {
            return new Vector3(a + b.X, a + b.Y, a + b.Z);
        }

        public static Vector3 operator -(double a, Vector3 b)
        {
            return new Vector3(a - b.X, a - b.Y, a - b.Z);
        }

        public static Vector3 operator *(double a, Vector3 b)
        {
            return new Vector3(a * b.X, a * b.Y, a * b.Z);
        }

        public static Vector3 operator /(double a, Vector3 b)
        {
            return new Vector3(a / b.X, a / b.Y, a / b.Z);
        }

        public static Vector3 operator %(double a, Vector3 b)
        {
            return new Vector3(a % b.X, a % b.Y, a % b.Y);
        }

        #endregion

        #region Constants

        public static readonly Vector3 Zero = new Vector3(0, 0, 0);
        public static readonly Vector3 One = new Vector3(1, 1, 1);

        public static readonly Vector3 Up = new Vector3(0, 1, 0);
        public static readonly Vector3 Down = new Vector3(0, -1, 0);
        public static readonly Vector3 Left = new Vector3(-1, 0, 0);
        public static readonly Vector3 Right = new Vector3(1, 0, 0);
        public static readonly Vector3 Backwards = new Vector3(0, 0, -1);
        public static readonly Vector3 Forwards = new Vector3(0, 0, 1);

        public static readonly Vector3 East = new Vector3(1, 0, 0);
        public static readonly Vector3 West = new Vector3(-1, 0, 0);
        public static readonly Vector3 North = new Vector3(0, 0, -1);
        public static readonly Vector3 South = new Vector3(0, 0, 1);

        #endregion

        public bool Equals(Vector3 other)
        {
            return other.X.Equals(X) && other.Y.Equals(Y) && other.Z.Equals(Z);
        }

        public bool Equals(float other)
        {
            return other.Equals(X) && other.Equals(Y) && other.Equals(Z);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Vector3)obj);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }
    }
}
