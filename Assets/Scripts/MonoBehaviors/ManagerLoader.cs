using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    public class ManagerLoader : MonoBehaviour
    {
        [SerializeField] private NameLaterManager nameLaterManager;

        private void Awake()
        {
            nameLaterManager.Initialize();
        }
    }
}