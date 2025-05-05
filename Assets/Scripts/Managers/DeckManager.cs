using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "DeckManager", menuName = "Managers/DeckManager")]
    public class DeckManager : ScriptableObject
    {
        [SerializeField] private Zone deckZone;
        [SerializeField] private DeckData deckData;

        private void Awake()
        {
            // init the deck
            // putt all cards in deck zone.
        }
    }
}