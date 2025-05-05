using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
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
            foreach (CardSet cardSet in deckData.CardSets)
            {
                for (int i = 0; i < cardSet.Count; i++)
                {
                    Card card = Instantiate(cardPrefab);

                    card.Initialize(cardSet.CardData, imageIndex: i);

                    deckZoneRuntimeSet.AddCard(card);

                    // todo
                    //AddCard(card);
                }
            }

            Card cardToMove = deckZoneRuntimeSet.Cards[2];
            deckZoneRuntimeSet.RemoveCard(cardToMove);
            handZoneRuntimeSet.AddCard(cardToMove);

            cardToMove = deckZoneRuntimeSet.Cards[3 - 1];
            deckZoneRuntimeSet.RemoveCard(cardToMove);
            handZoneRuntimeSet.AddCard(cardToMove);

            cardToMove = deckZoneRuntimeSet.Cards[6 - 2];
            deckZoneRuntimeSet.RemoveCard(cardToMove);
            handZoneRuntimeSet.AddCard(cardToMove);
        }
    }
}