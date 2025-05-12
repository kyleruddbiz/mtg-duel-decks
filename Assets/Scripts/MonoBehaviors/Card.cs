using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class Card : MonoBehaviour
    {
        [Header(HeaderConstants.Internal)]
        [SerializeField] private SpriteRenderer visual;
        [SerializeField] private GameObject border;

        [Header(HeaderConstants.Fields)]
        [SerializeField] private CardData cardData;
        [SerializeField] private int imageIndex;

        [field: SerializeField] public Player ControllingPlayer { get; private set; }

        public ZoneRuntimeSet CurrentZone { get; set; }

        public string CardName => cardData.CardName;
        public CardType CardType => cardData.CardType;
        public CardSuperType[] CardSuperTypes => cardData.CardSuperTypes;
        public CardSubType[] CardSubTypes => cardData.CardSubTypes;
        public ManaCost[] ManaCosts => cardData.ManaCosts;
        public CardTraits CardTraits { get; private set; }
        public Command[] Commands => cardData.Commands;

        private void Awake()
        {
            UpdateVisual();
        }

        private void Start()
        {
            CardTraits = cardData.CardTraits;
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

        private bool blarr = false;

        private void OnMouseUp()
        {
            // TODO - Just for testing right now.

            if (!blarr)
            {
                blarr = true;
                AddTraits(CardTraits.Deathtouch | CardTraits.Hexproof);

                Debug.Log(CardTraits);
            }
            else
            {
                blarr = false;
                RemoveTraits(CardTraits.Deathtouch | CardTraits.Hexproof);

                Debug.Log(CardTraits);
            }

            // GameManager.Instance.CastSpell(this);
        }

        public void Initialize(Player controllingPlayer, CardData cardData, int imageIndex)
        {
            ControllingPlayer = controllingPlayer;

            this.cardData = cardData;
            this.imageIndex = imageIndex;

            UpdateVisual();
        }

        public void MoveToZone(ZoneRuntimeSet destinationZone)
        {
            ZoneRuntimeSet.MoveCard(this, destinationZone);
        }

        private void UpdateVisual()
        {
            if (cardData == null)
            {
                return;
            }

            border.SetActive(IsWip());
            visual.sprite = cardData.CardImages[imageIndex];
        }

        public void AddTraits(CardTraits toAdd)
        {
            CardTraits |= toAdd;
        }

        public void RemoveTraits(CardTraits toRemove)
        {
            CardTraits &= ~toRemove;
        }

        public override string ToString()
        {
            return $"{(IsWip() ? "[WIP]" : "")}{cardData.name} ({imageIndex})";
        }

        private bool IsWip()
        {
            if (cardData.IsWip)
            {
                return true;
            }

            foreach (Command command in Commands)
            {
                if (command.IsWip)
                {
                    return true;
                }
            }

            return false;
        }
    }
}