using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class ManaCost
    {
        [field: SerializeField] public Color Color { get; private set; }
        [field: SerializeField] public int Amount { get; private set; }
    }
}