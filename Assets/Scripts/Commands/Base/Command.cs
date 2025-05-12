using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class Command
    {
        [field: SerializeField] public bool IsWip { get; private set; } = true;

        [SerializeField] private CommandAction action;
        [SerializeField] private When[] when;
        [SerializeField] private CommandParameter[] parameters;
        [SerializeField] private CardQuery[] queries;

        public void Execute(Card sourceCard)
        {
            Debug.Log("Executing command: " + action.name);

            action.Execute(sourceCard, parameters);
        }
    }
}