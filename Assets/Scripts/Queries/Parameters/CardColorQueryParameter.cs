using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardColorQueryParameter : QueryParameter<Color>
    {
        [field: SerializeField] public override Color Value { get; protected set; }
        [field: SerializeField] public override bool IsNegated { get; protected set; }
    }
}