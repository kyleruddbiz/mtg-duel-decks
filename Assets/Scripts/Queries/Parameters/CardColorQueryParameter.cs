using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardColorQueryParameter : QueryParameter<MtgColors>
    {
        [field: SerializeField] public override MtgColors Value { get; protected set; }
        [field: SerializeField] public override bool IsNegated { get; protected set; }
    }
}