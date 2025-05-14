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
        HexproofUnlessGreen = 256,
        Vigilance = 512,
        Defender = 1024,
        Devoid = 2048,
        CantBeCountered = 4096,
        // Next 8192,
    }
}