//using System;
//using UnityEngine;

//namespace VoidScribe.MtgDuelDecks
//{
//    [Serializable]
//    public class Command
//    {
//        [field: SerializeField] public bool IsWip { get; private set; } = true;

//        [SerializeField] private CommandAction action;
//        [SerializeField] private When[] when;
//        [SerializeField] private CommandParameter[] parameters;
//        [SerializeField] private CardQuery[] queries;

//        public async Awaitable ExecuteAsync(Card sourceCard)
//        {
//            Debug.Log("Executing command: " + action.name);

//            await action.ExecuteAsync(sourceCard, parameters);
//        }
//    }

//    // At most one Immediate command (can have multiple steps).
//    // Any number of Activated commands
//    // Any number of Triggered commands (listeners)
//    // Any number of Passive commands
//    // Alternative costs might be considered commands
//    // At most one Modal command (which is immediate). Can be conditional for number of selections allowed.
//    //
//    // Set state action

//    // All non-permanents have an immediate action. They don't have activated or triggered or passive.
//    // I bet i can add a permanent and non-permanent version of cardData to the hierarchy.

//    // Is doing this within the main project too complicated? Maybe test in separate project?
//}