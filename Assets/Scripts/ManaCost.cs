using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class ManaCost
    {
        public static class Properties
        {
            public const string Colors = nameof(colors);

            public static string ForColorAmount(MtgCostColors color)
            {
                return color switch
                {
                    MtgCostColors.Generic => PropertiesUtility.ToBackingFieldName(nameof(AmountGeneric)),
                    MtgCostColors.White => nameof(amountWhite),
                    MtgCostColors.Blue => nameof(amountBlue),
                    MtgCostColors.Black => nameof(amountBlack),
                    MtgCostColors.Red => nameof(amountRed),
                    MtgCostColors.Green => nameof(amountGreen),
                    _ => throw new ArgumentOutOfRangeException(color.ToString())
                };
            }
        }

        [SerializeField] private MtgCostColors colors;

        [field: SerializeField] public int AmountGeneric { get; private set; }
        [SerializeField] private int amountWhite;
        [SerializeField] private int amountBlue;
        [SerializeField] private int amountBlack;
        [SerializeField] private int amountRed;
        [SerializeField] private int amountGreen;

        public Dictionary<MtgColor, int> GetColorCosts()
        {
            var costs = new Dictionary<MtgColor, int>();

            AddIfApplicable(MtgCostColors.White, amountWhite);
            AddIfApplicable(MtgCostColors.Blue, amountBlue);
            AddIfApplicable(MtgCostColors.Black, amountBlack);
            AddIfApplicable(MtgCostColors.Red, amountRed);
            AddIfApplicable(MtgCostColors.Green, amountGreen);

            return costs;

            void AddIfApplicable(MtgCostColors color, int amount)
            {
                if (colors.HasFlag(color) && amount > 0)
                {
                    costs[(MtgColor)color] = amount;
                }
            }
        }

        public MtgColors ToCardColors()
        {
            // Strips generic.
            // If there are only generic costs, this will automatically convert to Colorless.
            MtgCostColors cleanSource = colors & ~MtgCostColors.Generic;

            return (MtgColors)cleanSource;
        }
    }
}