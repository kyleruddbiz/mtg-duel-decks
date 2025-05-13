using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class CreatureCardData : CardData
    {
        [field: SerializeField] public int Power { get; private set; }
        [field: SerializeField] public int Toughness { get; private set; }

        private void OnValidate()
        {
            CardTypes |= CardTypes.Creature;
        }
    }
}