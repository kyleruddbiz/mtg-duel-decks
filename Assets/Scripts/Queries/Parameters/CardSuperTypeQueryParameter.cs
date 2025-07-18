using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardSuperTypeQueryParameter : QueryParameter<CardSuperTypes>
    {
        [field: SerializeField] public override CardSuperTypes Value { get; protected set; }
        [field: SerializeField] public override bool IsNegated { get; protected set; }
    }
}