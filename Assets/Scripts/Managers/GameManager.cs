using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    /// <summary>
    /// This will be the random collector of a bunch of logic as I'm playing around with stuff.
    /// I'll split it into smaller pieces as I understand things better.
    /// </summary>
    [CreateAssetMenu(fileName = "GameManager", menuName = "Managers/GameManager")]
    public class GameManager : ScriptableObject
    {
        [SerializeField] private Card cardPrefab;
        [SerializeField] private DeckData deckData;

        [Header("Runtime Sets")]
        [SerializeField] private ZoneRuntimeSet deckZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet graveyardZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet exileZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet battlefieldZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet handZoneRuntimeSet;

        public void Initialize()
        {
            InitializeDeck();

            deckZoneRuntimeSet.Cards[0].MoveToZone(handZoneRuntimeSet);
            deckZoneRuntimeSet.Cards[0].MoveToZone(handZoneRuntimeSet);
        }

        private void InitializeDeck()
        {
            var cards = new List<Card>();

            foreach (CardSet cardSet in deckData.CardSets)
            {
                for (int i = 0; i < cardSet.Count; i++)
                {
                    Card card = Instantiate(cardPrefab);
                    card.Initialize(cardSet.CardData, imageIndex: i);

                    int insertIndex = Random.Range(0, cards.Count);
                    cards.Insert(insertIndex, card);
                }
            }

            foreach (Card card in cards)
            {
                deckZoneRuntimeSet.AddCard(card);
            }
        }
    }
}