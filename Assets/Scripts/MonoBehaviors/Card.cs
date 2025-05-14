using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class Card : MonoBehaviour, ITarget
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

        // TODO - I wonder if these are just used for query. If so, is it worth internalizing the query logic in card?
        public CardTypes CardTypes => cardData.CardTypes;
        public CardSuperTypes CardSuperTypes => cardData.CardSuperTypes;
        public CardSubType[] CardSubTypes => cardData.CardSubTypes;
        public ManaCost[] ManaCosts => cardData.ManaCosts;
        public CardTraits CardTraits { get; private set; }

        public bool IsPermanent => cardData.CardTypes.IsPermanent();

        public CardColors Colors
        {
            get
            {
                if (CardTraits.HasFlag(CardTraits.Devoid))
                {
                    return CardColors.Colorless;
                }

                return ManaCosts
                    .Select(manaCost => manaCost.Color)
                    .ToCardColors();
            }
        }

        private void Awake()
        {
            UpdateVisual();
        }

        private void Start()
        {
            CardTraits = cardData.CardTraits;
        }

        private void OnMouseUp()
        {
            GameManager.Instance.TrySetAsTarget(this);
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

        public async Awaitable ExecuteSpellAbilityAsync()
        {
            await cardData.SpellAbility.ExecuteAsync();
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

            //foreach (Command command in Commands)
            //{
            //    if (command.IsWip)
            //    {
            //        return true;
            //    }
            //}

            return false;
        }
    }
}