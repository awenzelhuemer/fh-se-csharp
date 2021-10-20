using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swk5.Extensions
{
    public static class CollectionExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> itemsd, Action<T> action)
        {
            if(action is null)
            {
                throw new ArgumentNullException("Parameter action is null");
            }

            foreach (var item in itemsd)
            {
                action(item);
            }
        }

        public static void AddAll<T>(this ICollection<T> target, IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                target.Add(item);
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (var item in items)
            {
                if(predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> items, Func<T, R> transform)
        {
            foreach (var item in items)
            {
                yield return transform(item);
            }
        }
    }
}
