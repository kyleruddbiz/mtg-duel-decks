namespace VoidScribe.MtgDuelDecks
{
    public readonly struct ManaCost
    {
        public ManaCost(Color color, int amount)
        {
            Color = color;
            Amount = amount;
        }

        public Color Color { get; }
        public int Amount { get; }
    }
}