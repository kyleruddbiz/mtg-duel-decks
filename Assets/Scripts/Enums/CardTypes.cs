using System;

namespace VoidScribe.MtgDuelDecks
{
    [Flags]
    public enum CardTypes
    {
        None = 0,

        // Spells
        Sorcery = 1,
        Instant = 2,

        // Permanents
        Creature = 4,
        Enchantment = 8,
        Artifact = 16,
        Planeswalker = 32,
        Land = 64,
        Battle = 128,

        AllPermanents = Creature | Enchantment | Artifact | Planeswalker | Land | Battle,
        AllSpells = Sorcery | Instant,
    }

    public enum SpellCardType
    {
        Sorcery = CardTypes.Sorcery,
        Instant = CardTypes.Instant,
    }

    [Flags]
    public enum PermanentCardTypes
    {
        None = CardTypes.None,
        Creature = CardTypes.Creature,
        Enchantment = CardTypes.Enchantment,
        Artifact = CardTypes.Artifact,
        Planeswalker = CardTypes.Planeswalker,
        Land = CardTypes.Land,
        Battle = CardTypes.Battle,
    }

    public static class CardTypesExtensions
    {
        public static bool IsPermanent(this CardTypes cardTypes)
        {
            return (cardTypes & CardTypes.AllPermanents) != 0;
        }
    }
}