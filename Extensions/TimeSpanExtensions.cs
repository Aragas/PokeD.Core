using System;

using PokeD.Core.Interfaces;

namespace PokeD.Core.Extensions
{
    public static class TimeSpanExtensions
    {
        public static void ToStream(this TimeSpan timeSpan, IPacketStream stream)
        {
            stream.WriteLong(timeSpan.Ticks);
        }

        public static TimeSpan FromReader(IPacketDataReader reader)
        {
            return new TimeSpan(reader.ReadLong());
        }
    }
}
