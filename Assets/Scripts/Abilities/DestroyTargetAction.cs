using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "DestroyTargetAction", menuName = "VoidScribe/Abilities/DestroyTargetAction")]
    public class DestroyTargetAction : SingleTargetAbilityAction
    {
        public override async Awaitable ExecuteInternalAsync(Context context)
        {
            Debug.Log("Choosing target card to destroy.");

            Card targetCard = await GameManager.Instance.ChooseTargetCardAsync(context.Query);

            Debug.Log("Destroying target card - " + targetCard.CardName);

            GameManager.Instance.DestroyCard(targetCard);
        }
    }
}