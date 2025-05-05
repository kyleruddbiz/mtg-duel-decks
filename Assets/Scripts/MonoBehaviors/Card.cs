using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer visual;
        [SerializeField] private int imageIndex;
        [SerializeField] private CardData cardData;

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
    }
}