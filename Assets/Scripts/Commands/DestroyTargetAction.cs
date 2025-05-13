//using UnityEngine;

//namespace VoidScribe.MtgDuelDecks
//{
//    [CreateAssetMenu(fileName = "DestroyTargetAction", menuName = "VoidScribe/Commands/DestroyTargetAction")]
//    public class DestroyTargetAction : ParameterlessCommandAction
//    {
//        // TODO - Add Query

//        protected override async Awaitable ExecuteAsync(Card sourceCard)
//        {
//            Debug.Log("Choosing target card to destroy.");

//            Card targetCard = await GameManager.Instance.ChooseTargetCardAsync();

//            Debug.Log("Destroying target card - " + targetCard.CardName);

//            GameManager.Instance.DestroyCard(targetCard);
//        }
//    }
//}