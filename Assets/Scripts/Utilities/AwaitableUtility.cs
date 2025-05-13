using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public static class AwaitableUtility
    {
        private static readonly AwaitableCompletionSource completionSource = new();

        public static Awaitable CompletedAwaitable
        {
            get
            {
                completionSource.SetResult();

                return completionSource.ResetAndReturnAwaitable();
            }
        }
    }
}