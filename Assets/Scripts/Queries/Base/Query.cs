using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public abstract class Query
    {
        protected abstract bool IsNegated { get; set; }

        public bool IsMatch(object source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source cannot be null.");
            }

            bool isMatch = IsMatchInternal(source);

            return IsNegated ? !isMatch : isMatch;
        }

        protected abstract bool IsMatchInternal(object source);
    }
}