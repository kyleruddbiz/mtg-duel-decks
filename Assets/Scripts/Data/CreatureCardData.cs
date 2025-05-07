using UnityEngine;

namespace VoidScribe.MtgDuelDecks.Assets.Scripts.Data
{
    public class CreatureCardData : CardData
    {
        public override CardType CardType => base.CardType;

        [field: SerializeField] public int Power { get; private set; }
        [field: SerializeField] public int Toughness { get; private set; }
    }
}