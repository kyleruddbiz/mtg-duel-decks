using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public abstract class AbilityAction : ScriptableObject
    {
        public abstract Awaitable ExecuteAsync(object context);
    }

    public abstract class AbilityAction<TContext> : AbilityAction
    {
        public override async Awaitable ExecuteAsync(object context)
        {
            if (context is not TContext contextInternal)
            {
                throw new ArgumentException($"{nameof(context)} must be of type {typeof(TContext).Name}");
            }

            await ExecuteInternalAsync(contextInternal);
        }

        public abstract Awaitable ExecuteInternalAsync(TContext context);
    }
}