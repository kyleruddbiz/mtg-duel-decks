using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [Serializable]
    public class CardQuery : ParameterBasedQuery<Card>
    {
        protected override bool IsNegated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [SerializeField] private CardTypeQueryParameter cardTypes;
        [SerializeField] private CardSuperTypeQueryParameter superTypes;
        [SerializeField] private CardSubTypeQueryParameter[] subTypes;
        [SerializeField] private CardColorQueryParameter[] colors;

        protected override bool IsMatchInternal(Card source)
        {
            throw new NotImplementedException();

            //if (isPermanent)
            //{
            //    if (!source.IsPermanent)
            //    {
            //        return false;
            //    }
            //}
            //else if (source.CardType != cardType)
            //{
            //    return false;
            //}

            //if (superTypes.Length != 0 && !source.CardSuperTypes.ContainsAll(superTypes))
            //{
            //    return false;
            //}

            //if (subTypes.Length != 0 && !source.CardSubTypes.ContainsAll(subTypes))
            //{
            //    return false;
            //}

            //if (colors.Length != 0 && !source.Colors.ContainsAll(colors))
            //{
            //    return false;
            //}

            //return true;
        }
    }
}