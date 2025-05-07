using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    [CreateAssetMenu(fileName = "ManaManager", menuName = "VoidScribe/Managers/ManaManager")]
    public class ManaManager : ScriptableObject
    {
        protected readonly Dictionary<Color, int> availableMana = new();

        public int GetAvailableMana(Color color)
        {
            return availableMana.TryGetValue(color, out int amount) ? amount : 0;
        }

        public void AddMana(Color color, int amount)
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
            foreach (ManaCost manaCost in manaCosts)
            {
                if (!HasEnoughMana(manaCost))
                {
                    return false;
                }
            }

            foreach (ManaCost manaCost in manaCosts)
            {
                availableMana[manaCost.Color] -= manaCost.Amount;
            }

            return true;
        }

        private bool HasEnoughMana(ManaCost manaCost)
        {
            return HasEnoughMana(manaCost.Color, manaCost.Amount);
        }

        private bool HasEnoughMana(Color color, int amount)
        {
            return availableMana.TryGetValue(color, out int availableAmount)
                && availableAmount >= amount;
        }
    }
}