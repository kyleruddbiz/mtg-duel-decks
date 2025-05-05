using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class Zone : MonoBehaviour
    {
        [SerializeField] private Transform cardsDisplay;
        [SerializeField] private TextMeshPro zoneNameText;
        [SerializeField] private string zoneName;
        [SerializeField] private float horizontalOffset;
        [SerializeField] private List<Card> cards;

        public void Awake()
        {
            zoneNameText.text = zoneName;

            UpdateVisual();
        }

        private void Update()
        {
            // TODO Delete
            //UpdateVisual();
        }

        private void UpdateVisual()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].transform.SetParent(cardsDisplay);
                cards[i].transform.localPosition = new Vector3(horizontalOffset * i, 0, -(.01f * i));
            }
        }

        public void AddCard(Card card)
        {
            cards.Add(card);

            UpdateVisual();
        }

        public void RemoveCard(Card card)
        {
            cards.Remove(card);

            UpdateVisual();
        }
    }
}