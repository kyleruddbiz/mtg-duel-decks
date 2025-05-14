using System;
using System.Collections.Generic;

namespace VoidScribe.MtgDuelDecks
{
    public static class ManaColorExtensions
    {
        public static CardColors ToCardColors(this ManaColor item)
        {
            return item switch
            {
                ManaColor.White => CardColors.White,
                ManaColor.Blue => CardColors.Blue,
                ManaColor.Black => CardColors.Black,
                ManaColor.Red => CardColors.Red,
                ManaColor.Green => CardColors.Green,
                _ => throw new ArgumentOutOfRangeException(item.ToString())
            };
        }

        public static CardColors ToCardColors(this IEnumerable<ManaColor> items)
        {
            var result = CardColors.Colorless;

            foreach (ManaColor item in items)
            {
                if (item == ManaColor.Generic)
                {
                    continue;
                }

                result |= item.ToCardColors();
            }

            return result;
        }
    }
}