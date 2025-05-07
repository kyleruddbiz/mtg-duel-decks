using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class Command
    {
        [SerializeField] private CommandAction action;
        [SerializeField] private When when;
        [SerializeField] private CommandParameter[] parameters;

        public void Execute(Card sourceCard)
        {
            Debug.Log("Executing command: " + action.name);

            action.Execute(sourceCard, parameters);
        }
    }
}