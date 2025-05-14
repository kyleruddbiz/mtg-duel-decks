using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "ManaManager", menuName = "VoidScribe/Managers/ManaManager")]
    public class ManaManager : ScriptableObject
    {
        protected readonly Dictionary<ManaColor, int> availableMana = new();

        public int GetAvailableMana(ManaColor color)
        {
            return availableMana.TryGetValue(color, out int amount) ? amount : 0;
        }

        public void AddMana(ManaColor color, int amount)
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

        // TODO - Need to make this smarter to handle colorless mana
        public bool TrySpendMana(params ManaCost[] manaCosts)
        {
            // pull out the generic mana costs
            // TODO - This is a problem for more brain me.

            int expectedGenericMana = 0;

            foreach (ManaCost manaCost in manaCosts)
            {
                if (manaCost.Color == ManaColor.Generic)
                {
                    if (!HasEnoughMana(ManaColor.Colorless, manaCost.Amount))
                    {
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (!HasEnoughMana(manaCost))
                {
                    return false;
                }
            }

            foreach (ManaCost manaCost in manaCosts)
            {
                var color = manaCost.Color;

                if (color == ManaColor.Generic)
                {
                    color = ManaColor.Colorless;
                }

                availableMana[color] -= manaCost.Amount;
            }

            return true;
        }

        private bool HasEnoughMana(ManaCost manaCost)
        {
            return HasEnoughMana(manaCost.Color, manaCost.Amount);
        }

        private bool HasEnoughMana(ManaColor color, int amount)
        {
            return availableMana.TryGetValue(color, out int availableAmount)
                && availableAmount >= amount;
        }
    }
}