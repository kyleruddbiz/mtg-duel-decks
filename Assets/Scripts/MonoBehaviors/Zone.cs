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
        [SerializeField] private ZoneRuntimeSet zoneRuntimeSet;

        private bool needsUpdate = false;

        public void Awake()
        {
            zoneNameText.text = zoneName;

            if (zoneRuntimeSet != null)
            {
                zoneRuntimeSet.CardAdded += OnCardAdded;
                zoneRuntimeSet.CardRemoved += OnCardRemoved;
            }
        }

        private void Update()
        {
            if (needsUpdate)
            {
                needsUpdate = false;
                UpdateVisual();
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
            needsUpdate = true;
        }

        private void OnCardRemoved(Card card)
        {
            needsUpdate = true;
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