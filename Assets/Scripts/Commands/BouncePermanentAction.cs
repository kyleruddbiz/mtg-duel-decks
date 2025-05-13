//using System.Threading.Tasks;
//using UnityEngine;

//namespace VoidScribe.MtgDuelDecks
//{
//    //[CreateAssetMenu(fileName = "BouncePermanentAction", menuName = "VoidScribe/Commands/BouncePermanentAction")]
//    public class BouncePermanentAction : ParameterlessCommandAction
//    {
//        // TODO - Temp hack.
//        // Instead want to show the user all of the available cards that match the query.
//        // Then allow them to select one.
//        [SerializeField] private Card target;

//        protected override Awaitable ExecuteAsync(Card sourceCard)
//        {
//            // how do i get the target?
//            // Want a way to request a target, using the query.

//            //if (!cardTypeQuery.IsMatch(target))
//            //{
//            //    throw new System.InvalidOperationException($"Target {target} does not match the query {cardTypeQuery}");
//            //}

//            GameManager.Instance.ReturnToHand(target);

//            return AwaitableUtility.CompletedAwaitable;
//        }
//    }
//}