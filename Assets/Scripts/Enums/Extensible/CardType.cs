using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "CardType", menuName = "VoidScribe/Enums/CardType")]
    public class CardType : ScriptableObject
    {
        [field: SerializeField] public bool IsPermanent { get; private set; }
    }
}