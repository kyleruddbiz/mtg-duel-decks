namespace VoidScribe.MtgDuelDecks
{
    public abstract class SingleTargetAbilityAction : AbilityAction<SingleTargetAbilityAction.Context>
    {
        public class Context
        {
            public MtgColors Query { get; set; }
        }
    }
}