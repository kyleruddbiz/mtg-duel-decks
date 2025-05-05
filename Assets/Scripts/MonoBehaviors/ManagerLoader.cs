using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class ManagerLoader : MonoBehaviour
    {
        [SerializeField] private GameManager nameLaterManager;

        private void Awake()
        {
            nameLaterManager.Initialize();
        }
    }
}