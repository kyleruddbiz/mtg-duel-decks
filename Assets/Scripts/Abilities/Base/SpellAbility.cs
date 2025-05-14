using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public abstract class SpellAbility<TAction> where TAction : AbilityAction
    {
        [field: SerializeField] public bool IsWip { get; private set; } = true;

        protected abstract TAction Action { get; set; }

        public async Awaitable ExecuteAsync()
        {
            if (Action == null)
            {
                throw new ArgumentNullException(nameof(Action));
            }

            await ExecuteInternalAsync();
        }

        protected abstract Awaitable ExecuteInternalAsync();
    }
}