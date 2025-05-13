using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardTypeQueryParameter : QueryParameter<CardTypes>
    {
        [field: SerializeField] public override CardTypes Value { get; protected set; }
        [field: SerializeField] public override bool IsNegated { get; protected set; }
    }
}