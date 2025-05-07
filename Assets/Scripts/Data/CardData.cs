using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "Card", menuName = "VoidScribe/Data/Card")]
    public class CardData : ScriptableObject
    {
        // Cost
        // Power and Toughness
        // Card Type - Creature, Sorcery, Instant, etc.
        // Subtype - Human, Wizard, Warlock, etc.
        // Keyword Abilities - such as flying, trample, etc.
        // Activated abilities and static abilities

        [field: SerializeField] public bool IsWip { get; private set; } = true;
        [field: SerializeField] public string CardName { get; private set; }
        [field: SerializeField] public CardType CardType { get; private set; }
        [field: SerializeField] public Sprite[] CardImages { get; private set; }
        [field: SerializeField] public ManaCost[] ManaCosts { get; private set; }
        [field: SerializeField] public Command[] Commands { get; private set; }
    }
}