using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "BounceTargetAction", menuName = "VoidScribe/Abilities/BounceTargetAction")]
    public class BounceTargetAction : SingleTargetAbilityAction
    {
        public override async Awaitable ExecuteInternalAsync(Context context)
        {
            Debug.Log("Choosing target card to bounce.");

            Card targetCard = await GameManager.Instance.ChooseTargetCardAsync(context.Query);

            Debug.Log("Bouncing target card - " + targetCard.CardName);

            GameManager.Instance.BounceCard(targetCard);
        }
    }
}