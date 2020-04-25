using System;
using System.Collections.Generic;
using System.Linq;

namespace SheepTools.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (enumerable is List<T> list)
            {
                list.ForEach(action);
            }
            else
            {
                foreach (T item in enumerable)
                {
                    action(item);
                }
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable?.Any() != true;
        }
    }
}
