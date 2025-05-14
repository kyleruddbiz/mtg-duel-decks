using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "SpriteSet", menuName = "VoidScribe/Data/Sprite Set")]
    public class SpriteSetData : ScriptableObject
    {
        [SerializeField] private Sprite[] sprites;

        public Sprite this[int index]
        {
            get => sprites[index];
            set => sprites[index] = value;
        }
    }
}