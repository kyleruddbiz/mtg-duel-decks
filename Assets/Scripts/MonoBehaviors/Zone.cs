using TMPro;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class Zone : MonoBehaviour
    {
        [Header(HeaderConstants.Internal)]
        [SerializeField] private Transform cardsDisplay;
        [SerializeField] private TextMeshPro zoneNameText;

        [Header(HeaderConstants.Fields)]
        [SerializeField] private string zoneName;
        [SerializeField] private float horizontalOffset;
        [SerializeField] private ZoneRuntimeSet zoneRuntimeSet;

        public void Awake()
        {
            zoneNameText.text = zoneName;

            if (zoneRuntimeSet != null)
            {
                zoneRuntimeSet.CardAdded += OnCardAdded;
                zoneRuntimeSet.CardRemoved += OnCardRemoved;
            }
        }

        private void OnDestroy()
        {
            if (zoneRuntimeSet != null)
            {
                zoneRuntimeSet.CardAdded -= OnCardAdded;
                zoneRuntimeSet.CardRemoved -= OnCardRemoved;
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
            for (int i = 0; i < zoneRuntimeSet.Cards.Count; i++)
            {
                //Debug.Log("UPdate viss " + zoneRuntimeSet.Cards[i].name);

                Card card = zoneRuntimeSet.Cards[i];

                card.transform.SetParent(cardsDisplay);
                card.transform.localPosition = new Vector3(horizontalOffset * i, 0, -(.01f * i));
            }
        }
    }
}