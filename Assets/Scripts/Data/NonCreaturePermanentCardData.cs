using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "NonCreaturePermanentCard", menuName = "VoidScribe/Data/Permanent Card (Non-Creature)")]
    public class NonCreaturePermanentCardData : CardData
    {
        [SerializeField] protected PermanentCardTypes cardTypes;
        [field: SerializeField] public override CardSuperTypes CardSuperTypes { get; protected set; }
        [field: SerializeField] public override CardSubType[] CardSubTypes { get; protected set; }

        [field: SerializeField] public override CardTraits CardTraits { get; protected set; }

        public override CardTypes CardTypes => (CardTypes)cardTypes;
    }
}