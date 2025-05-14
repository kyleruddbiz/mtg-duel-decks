using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardColorQueryParameter : QueryParameter<CardColors>
    {
        [field: SerializeField] public override CardColors Value { get; protected set; }
        [field: SerializeField] public override bool IsNegated { get; protected set; }
    }
}