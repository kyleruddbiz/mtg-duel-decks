using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "TestManaManager", menuName = "VoidScribe/Managers/TestManaManager")]
    public class TestManaManager : ManaManager
    {
        [SerializeField] private bool sendIt;
        [SerializeField] private int setWhiteMana;
        [SerializeField] private int setBlueMana;
        [SerializeField] private int setBlackMana;
        [SerializeField] private int setRedMana;
        [SerializeField] private int setGreenMana;

        // Ultra-hack, baby!!
        private void OnValidate()
        {
            if (sendIt)
            {
                sendIt = false;

                if (setWhiteMana != -1)
                {
                    availableMana[Color.White] = setWhiteMana;
                    setWhiteMana = -1;
                }
                if (setBlueMana != -1)
                {
                    availableMana[Color.Blue] = setBlueMana;
                    setBlueMana = -1;
                }
                if (setBlackMana != -1)
                {
                    availableMana[Color.Black] = setBlackMana;
                    setBlackMana = -1;
                }
                if (setRedMana != -1)
                {
                    availableMana[Color.Red] = setRedMana;
                    setRedMana = -1;
                }
                if (setGreenMana != -1)
                {
                    availableMana[Color.Green] = setGreenMana;
                    setGreenMana = -1;
                }
            }
        }
    }
}