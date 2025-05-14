namespace VoidScribe.MtgDuelDecks
{
    public abstract class SingleTargetAbilityAction : AbilityAction<SingleTargetAbilityAction.Context>
    {
        public class Context
        {
            public CardColors Query { get; set; }
        }
    }
}