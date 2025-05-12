using System;

namespace VoidScribe.MtgDuelDecks
{
    public abstract class ParameterBasedQuery<TSource> : Query
    {
        protected override bool IsMatchInternal(object source)
        {
            if (source is not TSource typedSource)
            {
                throw new ArgumentException($"Source must be of type {typeof(TSource)}", nameof(source));
            }

            return IsMatchInternal(typedSource);
        }

        protected abstract bool IsMatchInternal(TSource source);
    }
}