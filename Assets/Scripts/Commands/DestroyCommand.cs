using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "DestroyTargetAction", menuName = "VoidScribe/Commands/DestroyTargetAction")]
    public class DestroyTargetAction : ParameterlessCommandAction
    {
        protected override void Execute(Card sourceCard)
        {
        }
    }
}