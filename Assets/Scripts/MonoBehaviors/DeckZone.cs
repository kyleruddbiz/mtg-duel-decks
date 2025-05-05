using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class DeckZone : Zone
    {
        [SerializeField] private Card cardPrefab;
        [SerializeField] private DeckData deckData;

        private new void Awake()
        {
            base.Awake();

            // populate with deck data.
            //deckData.cardsets

            foreach (CardSet cardSet in deckData.CardSets)
            {
                for (int i = 0; i < cardSet.Count; i++)
                {
                    Card card = Instantiate(cardPrefab);

                    card.Initialize(cardSet.CardData, imageIndex: i);

                    //AddCard(card);
                }
            }
        }
    }
}