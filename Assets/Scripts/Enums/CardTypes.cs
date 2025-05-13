using System;

namespace VoidScribe.MtgDuelDecks
{
    [Flags]
    public enum CardTypes
    {
        None = 0,
        Creature = 1,
        Enchantment = 2,
        Artifact = 4,
        Planeswalker = 8,
        Land = 16,
        Sorcery = 32,
        Instant = 64,
        Battle = 128,

        AllPermanents = Creature | Enchantment | Artifact | Planeswalker | Land | Battle,
        AllNonpermanents = Sorcery | Instant,
    }

    public static class CardTypesExtensions
    {
        public static bool IsPermanent(this CardTypes cardTypes)
        {
            return (cardTypes & CardTypes.AllPermanents) != 0;
        }
    }
}