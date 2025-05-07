using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    //[CreateAssetMenu(fileName = "DrawCardsAction", menuName = "VoidScribe/Commands/DrawCardsAction")]
    public class DrawCardsAction : CommandAction<int>
    {
        protected override void Execute(Card sourceCard, int numberOfCards)
        {
            // TODO - Draw a card from the deck
            Debug.Log($"Drawing {numberOfCards} cards from the deck.");
        }
    }
}