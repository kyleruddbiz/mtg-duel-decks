using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public static class AwaitableCompletionSourceExtensions
    {
        public static Awaitable ResetAndReturnAwaitable(this AwaitableCompletionSource source)
        {
            source.Reset();

            return source.Awaitable;
        }

        public static Awaitable<T> ResetAndReturnAwaitable<T>(this AwaitableCompletionSource<T> source)
        {
            source.Reset();

            return source.Awaitable;
        }
    }
}