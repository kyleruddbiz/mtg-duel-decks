using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public abstract class CardData : ScriptableObject
    {
        [field: SerializeField] public bool IsWip { get; private set; } = true;
        [field: SerializeField] public string CardName { get; private set; }
        [field: SerializeField] public SpriteSetData CardImages { get; private set; }
        [field: SerializeField] public ManaCost ManaCost { get; private set; }

        public abstract CardTypes CardTypes { get; }
        public abstract CardSuperTypes CardSuperTypes { get; protected set; }
        public abstract CardSubType[] CardSubTypes { get; protected set; }

        public abstract CardTraits CardTraits { get; protected set; }
    }
}