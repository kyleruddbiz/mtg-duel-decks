using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardSuperTypeQueryParameter : QueryParameter<CardSuperType>
    {
        [field: SerializeField] public override CardSuperType Value { get; protected set; }
        [field: SerializeField] public override bool IsNegated { get; protected set; }
    }
}