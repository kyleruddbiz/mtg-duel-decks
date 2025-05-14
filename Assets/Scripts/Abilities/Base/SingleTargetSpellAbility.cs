using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class SingleTargetSpellAbility : SpellAbility<SingleTargetAbilityAction>
    {
        [field: SerializeField] protected override SingleTargetAbilityAction Action { get; set; }
        [SerializeField] private CardColors query;

        protected override async Awaitable ExecuteInternalAsync()
        {
            await Action.ExecuteInternalAsync(new SingleTargetAbilityAction.Context { Query = query });
        }
    }
}