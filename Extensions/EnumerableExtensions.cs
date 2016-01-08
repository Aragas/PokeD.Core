using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeD.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static TSource MinOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source.Any())
                return source.Min();
            else
                return default(TSource);
        }

        public static int MinOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source.Any())
                return source.Min(selector);
            else
                return 0;
        }
    }
}