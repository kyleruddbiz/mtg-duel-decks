using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "SpellCard", menuName = "VoidScribe/Data/Spell Card")]
    public class SpellCardData : CardData
    {
        [SerializeField] private SpellCardType cardType;
        [field: SerializeField] public override CardSuperTypes CardSuperTypes { get; protected set; }
        [field: SerializeField] public override CardSubType[] CardSubTypes { get; protected set; }

        [field: SerializeField] public override CardTraits CardTraits { get; protected set; }
        [field: SerializeField] public SingleTargetSpellAbility SpellAbility { get; private set; }

        public override CardTypes CardTypes => (CardTypes)cardType;
    }
}