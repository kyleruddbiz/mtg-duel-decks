using System.Threading.Tasks;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public static class AwaitableCompletionSourceExtensions
    {
        public static async Awaitable AwaitAndReset(this AwaitableCompletionSource source)
        {
            try
            {
                await source.Awaitable;
            }
            finally
            {
                source.Reset();
            }
        }

        public static async Awaitable<T> AwaitAndReset<T>(this AwaitableCompletionSource<T> source)
        {
            T value = default;

            try
            {
                value = await source.Awaitable;
            }
            finally
            {
                source.Reset();
            }

            return value;
        }
    }
}