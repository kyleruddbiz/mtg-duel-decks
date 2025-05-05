using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private int imageIndex;
        [SerializeField] private CardData cardData;
        [SerializeField] private SpriteRenderer visual;

        private void Awake()
        {
            visual.sprite = cardData.CardImages[imageIndex];
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
    }
}