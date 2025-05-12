using System.Threading.Tasks;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class TargetManager : MonoBehaviour
    {
        public static TargetManager Instance { get; private set; }

        // TODO - just for testing. Remove later.
        [field: SerializeField] public Card TargetCard { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        public async Awaitable<Card> GetTargetCard()
        {
            await Awaitable.WaitForSecondsAsync(1f);

            return TargetCard;
        }
    }
}