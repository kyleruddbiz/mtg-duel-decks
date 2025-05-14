using System;

namespace VoidScribe.MtgDuelDecks
{
    [Flags]
    public enum CardColors
    {
        Colorless = 0,
        White = 1,
        Blue = 2,
        Black = 4,
        Red = 8,
        Green = 16,
    }
}