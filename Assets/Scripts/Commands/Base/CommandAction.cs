//using UnityEngine;

//namespace VoidScribe.MtgDuelDecks
//{
//    public abstract class CommandAction : ScriptableObject
//    {
//        public abstract Awaitable ExecuteAsync(Card sourceCard, params CommandParameter[] parameters);
//    }

//    public abstract class ParameterlessCommandAction : CommandAction
//    {
//        public override async Awaitable ExecuteAsync(Card sourceCard, params CommandParameter[] parameters)
//        {
//            if (parameters.Length != 0)
//            {
//                throw new System.ArgumentException("Expected no parameters.");
//            }

//            await ExecuteAsync(sourceCard);
//        }

//        protected abstract Awaitable ExecuteAsync(Card sourceCard);
//    }

//    public abstract class CommandAction<T> : CommandAction
//    {
//        public override async Awaitable ExecuteAsync(Card sourceCard, params CommandParameter[] parameters)
//        {
//            if (parameters.Length != 1)
//            {
//                throw new System.ArgumentException($"Expected a single parameter of type {typeof(T)}.");
//            }

//            await ExecuteAsync(sourceCard, (T)parameters[0].Value);
//        }

//        protected abstract Awaitable ExecuteAsync(Card sourceCard, T parameter);
//    }
//}