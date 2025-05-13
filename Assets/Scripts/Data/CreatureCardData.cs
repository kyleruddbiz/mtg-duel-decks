using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class CreatureCardData : CardData
    {
        [field: SerializeField] public int Power { get; private set; }
        [field: SerializeField] public int Toughness { get; private set; }

        private void OnValidate()
        {
            if ((int)CardTypes == -1 // Everything
                || CardTypes == CardTypes.AllPermanents
                || CardTypes == CardTypes.AllNonpermanents
                || CardTypes == (CardTypes.Creature | CardTypes.AllNonpermanents))
            {
                CardTypes = CardTypes.None;
            }

            CardTypes |= CardTypes.Creature;
        }
    }
}