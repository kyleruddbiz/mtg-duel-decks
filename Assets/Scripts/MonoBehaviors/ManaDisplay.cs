using System;
using TMPro;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class ManaDisplay : MonoBehaviour
    {
        [Header(HeaderConstants.Internal)]
        [SerializeField] private SpriteRenderer image;
        [SerializeField] private TextMeshPro amountText;
        [SerializeField] private ManaDisplay_Square square;

        [Header(HeaderConstants.Fields)]
        [SerializeField] private ManaManager manaManager;
        [SerializeField] private Color color;
        [SerializeField] private Sprite symbolSprite;

        private void Awake()
        {
            image.sprite = symbolSprite;
            amountText.text = manaManager.GetAvailableMana(color).ToString();

            square.Clicked += OnClicked;
        }

        // TODO - Move this out of the update loop
        private void Update()
        {
            amountText.text = manaManager.GetAvailableMana(color).ToString();
        }

        private void OnClicked()
        {
            manaManager.AddMana(color, 1);
        }
    }
}