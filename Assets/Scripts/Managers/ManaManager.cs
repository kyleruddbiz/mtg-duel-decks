using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "ManaManager", menuName = "VoidScribe/Managers/ManaManager")]
    public class ManaManager : ScriptableObject
    {
        protected readonly Dictionary<MtgColor, int> availableMana = new();

        public int GetAvailableMana(MtgColor color)
        {
            return availableMana.TryGetValue(color, out int amount) ? amount : 0;
        }

        public void AddMana(MtgColor color, int amount)
        {
            if (availableMana.ContainsKey(color))
            {
                availableMana[color] += amount;
            }
            else
            {
                availableMana[color] = amount;
            }
        }

        public bool TrySpendMana(ManaCost manaCost)
        {
            var availableManaCopy = new Dictionary<MtgColor, int>(availableMana);

            foreach ((MtgColor color, int costAmount) in manaCost.GetColorCosts())
            {
                if (!availableManaCopy.TryGetValue(color, out int availableAmount))
                {
                    // NODO - If needed, support "Any" mana type here.
                    return false;
                }

                if (availableAmount > costAmount)
                {
                    availableManaCopy[color] -= costAmount;
                }
                else if (availableAmount == costAmount)
                {
                    availableManaCopy.Remove(color);
                }
                else
                {
                    // NODO - If needed, support "Any" mana type here.
                    return false;
                }
            }

            int genericCostAmount = manaCost.AmountGeneric;

            foreach ((MtgColor color, int availableAmount) in availableManaCopy.ToList())
            {
                if (genericCostAmount == 0)
                {
                    break;
                }

                if (availableAmount > 0)
                {
                    int amountToSpend = System.Math.Min(availableAmount, genericCostAmount);

                    if (availableAmount > amountToSpend)
                    {
                        availableManaCopy[color] -= amountToSpend;
                    }
                    else if (availableAmount == amountToSpend)
                    {
                        availableManaCopy.Remove(color);
                    }

                    genericCostAmount -= amountToSpend;
                }
            }

            if (genericCostAmount > 0)
            {
                return false;
            }

            availableMana.Clear();
            availableMana.AddRange(availableManaCopy);

            return true;
        }
    }
}