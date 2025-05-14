using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardQuery
    {
        [Flags]
        public enum Parameters
        {
            None = 0,
            Color = 1,
            CardType = 2,
        }

        public static CardQuery Empty => new()
        {
            ActiveParameters = Parameters.None,
            Colors = MtgColors.Colorless,
            CardTypes = CardTypes.None,
        };

        [field: SerializeField] private Parameters ActiveParameters { get; set; }
        [field: SerializeField] private MtgColors Colors { get; set; }
        [field: SerializeField] private CardTypes CardTypes { get; set; }

        public override string ToString()
        {
            if (ActiveParameters == Parameters.None)
            {
                return "No Query";
            }

            return $"Query({ActiveParameters}): {Colors}, {CardTypes}";
        }

        public bool IsMatch(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!IsColorMatch(card.Colors))
            {
                return false;
            }
            if (!IsCardTypeMatch(card.CardTypes))
            {
                return false;
            }

            return true;
        }

        private bool IsColorMatch(MtgColors colors)
        {
            if (!ActiveParameters.HasFlag(Parameters.Color))
            {
                return true;
            }

            return Colors.HasFlag(colors);
        }

        private bool IsCardTypeMatch(CardTypes cardTypes)
        {
            if (!ActiveParameters.HasFlag(Parameters.CardType))
            {
                return true;
            }

            return CardTypes.HasFlag(cardTypes);
        }
    }
}