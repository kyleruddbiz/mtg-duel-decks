using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "CreatureCard", menuName = "VoidScribe/Data/Creature Card")]
    public class CreatureCardData : PermanentCardData
    {
        [field: SerializeField] public int Power { get; private set; }
        [field: SerializeField] public int Toughness { get; private set; }

        private void OnValidate()
        {
            cardTypes |= PermanentCardTypes.Creature;
        }
    }
}