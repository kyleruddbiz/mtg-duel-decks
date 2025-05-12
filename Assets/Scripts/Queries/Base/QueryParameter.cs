namespace VoidScribe.MtgDuelDecks
{
    public abstract class QueryParameter<T>
    {
        public abstract T Value { get; protected set; }

        public abstract bool IsNegated { get; protected set; }
    }
}