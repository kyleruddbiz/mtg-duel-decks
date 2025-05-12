using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardSubTypeQueryParameter : QueryParameter<CardSubType>
    {
        [field: SerializeField] public override CardSubType Value { get; protected set; }
        [field: SerializeField] public override bool IsNegated { get; protected set; }
    }
}