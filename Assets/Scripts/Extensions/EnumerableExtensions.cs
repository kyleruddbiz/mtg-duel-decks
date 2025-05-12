using System;
using System.Collections.Generic;
using System.Linq;

namespace VoidScribe.MtgDuelDecks
{
    public static class EnumerableExtensions
    {
        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            return target.All(t => source.Contains(t));
        }

        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<QueryParameter<T>> target)
        {
            foreach (QueryParameter<T> queryParameter in target)
            {
                if (queryParameter.IsNegated)
                {
                    if (source.Contains(queryParameter.Value))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!source.Contains(queryParameter.Value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}