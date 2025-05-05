using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "NameLaterManager", menuName = "Managers/NameLaterManager")]
    public class NameLaterManager : ScriptableObject
    {
        [SerializeField] private Card cardPrefab;
        [SerializeField] private DeckData deckData;
        [SerializeField] private ZoneManager deckZoneManager;

        private List<Card> deckCards = new();
        private List<Card> graveyardCards = new();
        private List<Card> exileCards = new();
        private List<Card> handCards = new();
        private List<Card> battlefieldCards = new();

        public void Initialize()
        {
            int iz = 0;

            foreach (CardSet cardSet in deckData.CardSets)
            {
                for (int i = 0; i < cardSet.Count; i++)
                {
                    Card card = Instantiate(cardPrefab);

                    card.Initialize(cardSet.CardData, imageIndex: i);

                    deckZoneManager.AddCard(card);

                    // todo
                    //AddCard(card);
                }
            }
        }
    }
}