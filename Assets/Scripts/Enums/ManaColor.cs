namespace VoidScribe.MtgDuelDecks
{
    // Doesn't make sense to have colorless and generic.
    // When I'm paying a mana cost, I only support generic.
    // WHen I'm producing mana, I can be any.
    //
    // TODO - Switch to CardColors for mana produced.
    // TODO - Probably rename too.
    public enum ManaColor
    {
        Colorless,
        White,
        Blue,
        Black,
        Red,
        Green,
        Generic,
    }
}