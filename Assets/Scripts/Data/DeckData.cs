using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardSet
    {
        [field: SerializeField] public CardData CardData { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
    }

    [CreateAssetMenu(fileName = "Deck", menuName = "VoidScribe/Data/Deck")]
    public class DeckData : ScriptableObject
    {
        [field: SerializeField] public string DeckName { get; private set; }
        [field: SerializeField] public SpriteSetData SleeveImages { get; private set; }
        [field: SerializeField] public List<CardSet> CardSets { get; private set; }
    }
}