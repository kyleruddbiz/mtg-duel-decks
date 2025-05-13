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
        [field: SerializeField] public ManaCost[] ManaCosts { get; private set; }

        [field: SerializeField] public CardTypes CardTypes { get; protected set; }
        [field: SerializeField] public CardSuperTypes CardSuperTypes { get; private set; }
        [field: SerializeField] public CardSubType[] CardSubTypes { get; private set; }

        [field: SerializeField] public CardTraits CardTraits { get; private set; }
        [field: SerializeField] public Command[] Commands { get; private set; }

        // TODO (Kind of) - Activated abilities and static abilities
    }
}