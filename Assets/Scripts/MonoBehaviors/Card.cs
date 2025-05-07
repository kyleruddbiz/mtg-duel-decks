using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class Card : MonoBehaviour
    {
        [Header(HeaderConstants.PrefabInternal)]
        [SerializeField] private SpriteRenderer visual;

        [Header(HeaderConstants.Fields)]
        [SerializeField] private int imageIndex;
        [SerializeField] private CardData cardData;

        public ZoneRuntimeSet CurrentZone { get; set; }

        private void Awake()
        {
            UpdateVisual();
        }

        private void OnValidate()
        {
            if (cardData != null)
            {
                if (cardData.CardImages == null)
                {
                    throw new System.ArgumentNullException(nameof(cardData.CardImages));
                }

                if (imageIndex < 0 || imageIndex >= cardData.CardImages.Length)
                {
                    throw new System.ArgumentException("Image index is out of bounds for card data.");
                }
            }
        }

        private void OnMouseOver()
        {
            //Debug.Log("Mouse over - " + ToString());
        }

        private void OnMouseDown()
        {
            //Debug.Log("Mouse down - " + ToString());
        }

        private void OnMouseUp()
        {
            foreach (Command command in cardData.Commands)
            {
                command.Execute(this);
            }
        }

        public void MoveToZone(ZoneRuntimeSet destinationZone)
        {
            ZoneRuntimeSet.MoveCard(this, destinationZone);
        }

        public void Initialize(CardData cardData, int imageIndex)
        {
            this.cardData = cardData;
            this.imageIndex = imageIndex;

            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (cardData == null)
            {
                return;
            }

            visual.sprite = cardData.CardImages[imageIndex];
        }

        public override string ToString()
        {
            return $"{cardData.name} ({imageIndex})";
        }
    }
}