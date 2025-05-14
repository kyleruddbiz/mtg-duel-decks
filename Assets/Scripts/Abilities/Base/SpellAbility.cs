using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public abstract class SpellAbility<TAction> where TAction : AbilityAction
    {
        protected abstract TAction Action { get; set; }

        public abstract Awaitable ExecuteAsync();
    }
}