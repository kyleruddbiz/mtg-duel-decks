using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "NewCard", menuName = "Data/Card")]
    public class CardData : ScriptableObject
    {
        // Cost
        // Power and Toughness
        // Card Type - Creature, Sorcery, Instant, etc.
        // Subtype - Human, Wizard, Warlock, etc.
        // Keyword Abilities - such as flying, trample, etc.
        // Activated abilities and static abilities
        [field: SerializeField] public Sprite[] CardImages { get; private set; }
    }
}