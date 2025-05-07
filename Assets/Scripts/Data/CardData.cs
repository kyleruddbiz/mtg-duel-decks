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

        // TODO - These only apply to creatures and other special cases
        //[field: SerializeField] public int Power { get; private set; }
        //[field: SerializeField] public int Toughness { get; private set; }

        [field: SerializeField] public CardType CardType { get; private set; }
        [field: SerializeField] public CardSuperType[] CardSuperTypes { get; private set; }
        [field: SerializeField] public CardSubType[] CardSubTypes { get; private set; }
        [field: SerializeField] public ManaCost[] ManaCosts { get; private set; }
        [field: SerializeField] public Command[] Commands { get; private set; }

        // TODO (Kind of) - Keyword Abilities - such as flying, trample, etc.
        // TODO (Kind of) - Activated abilities and static abilities
    }
}