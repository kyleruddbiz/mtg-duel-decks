using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public abstract class CommandAction : ScriptableObject
    {
        public abstract void Execute(Card sourceCard, params CommandParameter[] parameters);
    }

    public abstract class ParameterlessCommandAction : CommandAction
    {
        public override void Execute(Card sourceCard, params CommandParameter[] parameters)
        {
            if (parameters.Length != 0)
            {
                throw new System.ArgumentException("Expected no parameters.");
            }

            Execute(sourceCard);
        }

        protected abstract void Execute(Card sourceCard);
    }

    public abstract class CommandAction<T> : CommandAction
    {
        public override void Execute(Card sourceCard, params CommandParameter[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new System.ArgumentException($"Expected a single parameter of type {typeof(T)}.");
            }

            Execute(sourceCard, (T)parameters[0].Value);
        }

        protected abstract void Execute(Card sourceCard, T parameter);
    }
}