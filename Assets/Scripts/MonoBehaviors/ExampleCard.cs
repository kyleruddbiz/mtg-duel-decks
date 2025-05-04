using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class ExampleCard : MonoBehaviour
    {
        [SerializeField] private CardData cardData;
        [SerializeField] private SpriteRenderer visual;

        private void Awake()
        {
            visual.sprite = cardData.CardImages[Random.Range(0, cardData.CardImages.Length)];
        }
    }
}