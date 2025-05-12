using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    // TODO - I want to make a property drawer for this CardType with isPermanent override.
    // Hide cardType if isPermanent is true.
    [Serializable]
    public class CardQuery : ParameterBasedQuery<Card>
    {
        [Tooltip("Will override cardType.")][SerializeField] private bool isPermanent;
        [SerializeField] private CardType cardType;
        [field: SerializeField] protected override bool IsNegated { get; set; }

        [SerializeField] private CardSuperTypeQueryParameter[] superTypes;
        [SerializeField] private CardSubTypeQueryParameter[] subTypes;
        [SerializeField] private CardColorQueryParameter[] colors;

        protected override bool IsMatchInternal(Card source)
        {
            if (isPermanent)
            {
                if (!source.CardType.IsPermanent)
                {
                    return false;
                }
            }
            else if (source.CardType != cardType)
            {
                return false;
            }

            if (superTypes.Length != 0 && !source.CardSuperTypes.ContainsAll(superTypes))
            {
                return false;
            }

            if (subTypes.Length != 0 && !source.CardSubTypes.ContainsAll(subTypes))
            {
                return false;
            }

            if (colors.Length != 0 && !source.Colors.ContainsAll(colors))
            {
                return false;
            }

            return true;
        }
    }
}