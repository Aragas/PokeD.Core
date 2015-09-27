using System;

using PokeD.Core.Interfaces;

namespace PokeD.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static void ToStream(this DateTime dateTime, IPacketStream stream)
        {
            stream.WriteLong(dateTime.Ticks);
        }

        public static DateTime FromReader(IPacketDataReader reader)
        {
            return new DateTime(reader.ReadLong());
        }
    }
}
