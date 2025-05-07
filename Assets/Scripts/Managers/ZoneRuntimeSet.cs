using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "ZoneRuntimeSet", menuName = "VoidScribe/RuntimeSets/ZoneRuntimeSet")]
    public class ZoneRuntimeSet : ScriptableObject
    {
        public event Action<Card> CardAdded;
        public event Action<Card> CardRemoved;

        private readonly List<Card> cards = new();
        public IReadOnlyList<Card> Cards => cards;

        public static void MoveCard(Card card, ZoneRuntimeSet destinationZone)
        {
            card.CurrentZone.RemoveCard(card);

            destinationZone.AddCard(card);
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
            card.CurrentZone = this;

            CardAdded?.Invoke(card);
        }

        public void RemoveCard(Card card)
        {
            cards.Remove(card);
            card.CurrentZone = null;

            CardRemoved?.Invoke(card);
        }
    }
}