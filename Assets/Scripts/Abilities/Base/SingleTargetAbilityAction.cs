namespace VoidScribe.MtgDuelDecks
{
    public abstract class SingleTargetAbilityAction : AbilityAction<SingleTargetAbilityAction.Context>
    {
        public class Context
        {
            public CardQuery Query { get; set; }
        }
    }
}