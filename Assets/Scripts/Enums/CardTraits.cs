using System;

namespace VoidScribe.MtgDuelDecks
{
    [Flags]
    public enum CardTraits
    {
        None = 0,
        Flying = 1,
        Haste = 2,
        Trample = 4,
        Deathtouch = 8,
        Lifelink = 16,
        Reach = 32,
        Indestructible = 64,
        Hexproof = 128,
        Vigilance = 256,
        Defender = 512,
        Devoid = 1024,
        CantBeCountered = 2048,
    }
}