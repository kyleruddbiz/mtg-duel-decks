using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public static class AwaitableUtility
    {
        private static readonly AwaitableCompletionSource completionSource = new();

        /// <summary>
        /// https://discussions.unity.com/t/awaitable-equivalent-of-task-completedtask/1546128/4
        /// </summary>
        public static Awaitable CompletedAwaitable
        {
            get
            {
                completionSource.SetResult();

                Awaitable awaitable = completionSource.Awaitable;

                completionSource.Reset();

                return awaitable;
            }
        }
    }
}