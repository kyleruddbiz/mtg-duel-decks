using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class Zone : MonoBehaviour
    {
        [Header(HeaderConstants.PrefabInternal)]
        [SerializeField] private Transform cardsDisplay;
        [SerializeField] private TextMeshPro zoneNameText;

        [Header(HeaderConstants.Fields)]
        [SerializeField] private string zoneName;
        [SerializeField] private float horizontalOffset;
        [SerializeField] private ZoneManager zoneManager;

        public void Awake()
        {
            zoneNameText.text = zoneName;
        }

        private void Start()
        {
            if (zoneManager != null)
            {
                zoneManager.CardAdded += OnCardAdded;
                zoneManager.CardRemoved += OnCardRemoved;
            }
        }

        private void OnDestroy()
        {
            if (zoneManager != null)
            {
                zoneManager.CardAdded -= OnCardAdded;
                zoneManager.CardRemoved -= OnCardRemoved;
            }
        }

        private void OnCardAdded(Card card)
        {
            UpdateVisual();
        }

        private void OnCardRemoved(Card card)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            for (int i = 0; i < zoneManager.Cards.Count; i++)
            {
                Debug.Log("UPdate viss " + zoneManager.Cards[i].name);

                Card card = zoneManager.Cards[i];

                card.transform.SetParent(cardsDisplay);
                card.transform.localPosition = new Vector3(horizontalOffset * i, 0, -(.01f * i));
            }
        }
    }
}