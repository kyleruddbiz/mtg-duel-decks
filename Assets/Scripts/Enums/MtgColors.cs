using System;

namespace VoidScribe.MtgDuelDecks
{
    [Flags]
    public enum MtgColors
    {
        Colorless = 0,
        White = 1,
        Blue = 2,
        Black = 4,
        Red = 8,
        Green = 16,
    }

    public enum MtgColor
    {
        Colorless = MtgColors.Colorless,
        White = MtgColors.White,
        Blue = MtgColors.Blue,
        Black = MtgColors.Black,
        Red = MtgColors.Red,
        Green = MtgColors.Green,
    }

    [Flags]
    public enum MtgCostColors
    {
        None = MtgColors.Colorless,
        Generic = 32,
        White = MtgColors.White,
        Blue = MtgColors.Blue,
        Black = MtgColors.Black,
        Red = MtgColors.Red,
        Green = MtgColors.Green,
    }
}