using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "ZoneManager", menuName = "Managers/ZoneManager")]
    public class ZoneManager : ScriptableObject
    {
        public event Action<Card> CardAdded;
        public event Action<Card> CardRemoved;

        private readonly List<Card> cards = new();
        public IReadOnlyList<Card> Cards => cards;

        public void AddCard(Card card)
        {
            cards.Add(card);

            CardAdded?.Invoke(card);
        }

        public void RemoveCard(Card card)
        {
            cards.Remove(card);

            CardRemoved?.Invoke(card);
        }
    }
}