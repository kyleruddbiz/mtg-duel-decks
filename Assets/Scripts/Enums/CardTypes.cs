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
    }

    public static class CardTypesExtensions
    {
        private const CardTypes PermanentCardTypes =
            CardTypes.Creature
            | CardTypes.Enchantment
            | CardTypes.Artifact
            | CardTypes.Planeswalker
            | CardTypes.Land
            | CardTypes.Battle;

        public static bool IsPermanent(this CardTypes cardTypes)
        {
            return (cardTypes & PermanentCardTypes) != 0;
        }
    }
}