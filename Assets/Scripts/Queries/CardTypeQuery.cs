using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardTypeQuery
    {
        [SerializeField] private CardType cardType;
        [SerializeField] private bool isNegated;

        public bool IsMatch(Card card)
        {
            if (cardType == null)
            {
                throw new ArgumentNullException(nameof(cardType), "CardType cannot be null.");
            }

            bool isMatch = card.CardType == cardType;

            return isNegated ? !isMatch : isMatch;
        }
    }
}