using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public abstract class CardData : ScriptableObject
    {
        [field: Header(HeaderConstants.Internal)]
        [field: SerializeField] public bool IsWip { get; private set; } = true;
        [field: SerializeField] public Sprite[] CardImages { get; private set; }

        [field: Header(HeaderConstants.Fields)]
        [field: SerializeField] public string CardName { get; private set; }

        [field: Tooltip("Use Colorless to represent generic mana costs.")]
        [field: SerializeField] public ManaCost[] ManaCosts { get; private set; }

        public abstract CardTypes CardTypes { get; }
        public abstract CardSuperTypes CardSuperTypes { get; protected set; }
        public abstract CardSubType[] CardSubTypes { get; protected set; }

        public abstract CardTraits CardTraits { get; protected set; }
    }
}