using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "Player", menuName = "VoidScribe/Player")]
    public class Player : ScriptableObject, ITarget
    {
        [field: SerializeField] public string PlayerName { get; private set; }
        [field: SerializeField] public DeckData DeckData { get; private set; }
        [field: SerializeField] public Player Opponent { get; private set; }
        [field: SerializeField] public int Health { get; private set; } = 20;

        public override string ToString()
        {
            return $"{PlayerName} ({Health} HP)";
        }
    }
}