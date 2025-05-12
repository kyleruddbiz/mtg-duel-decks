using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "Card", menuName = "VoidScribe/Data/Card")]
    public class CardData : ScriptableObject
    {
        // Internal
        [field: SerializeField] public bool IsWip { get; private set; } = true;
        [field: SerializeField] public Sprite[] CardImages { get; private set; }

        // Fields
        [field: SerializeField] public string CardName { get; private set; }

        // NODO - Choosing to ignore combo types for now (Artifact Creature).
        // They don't show up in these duel decks.
        [field: SerializeField] public virtual CardType CardType { get; private set; }
        [field: SerializeField] public CardSuperType[] CardSuperTypes { get; private set; }
        [field: SerializeField] public CardSubType[] CardSubTypes { get; private set; }
        [field: SerializeField] public ManaCost[] ManaCosts { get; private set; }

        [field: SerializeField] public CardTraits CardTraits { get; private set; }
        [field: SerializeField] public Command[] Commands { get; private set; }

        // TODO (Kind of) - Activated abilities and static abilities
    }
}