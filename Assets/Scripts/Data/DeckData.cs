using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [System.Serializable]
    public class CardSet
    {
        [SerializeField] private CardData cardData;
        [SerializeField] private int count;
    }

    [CreateAssetMenu(fileName = "NewDeck", menuName = "Data/Deck")]
    public class DeckData : ScriptableObject
    {
        [SerializeField] private string deckName;
        [SerializeField] private Sprite[] sleeveImages;
        [SerializeField] private List<CardSet> cardSets;
    }
}