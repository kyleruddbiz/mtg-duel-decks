using System;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class ManaDisplay_Square : MonoBehaviour
    {
        public event Action Clicked;

        private void OnMouseUp()
        {
            Clicked?.Invoke();
        }
    }
}