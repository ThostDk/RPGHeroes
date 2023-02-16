using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGHeroes.GameplayLoop
{
    public static class Reward
    {
        /// <summary>
        /// Method that adds a random item from the game to the target inventory
        /// </summary>
        /// <param name="rewardTakerInventory">the inventory which the reward will be added to</param>
        public static void GiveReward(Inventory rewardTakerInventory)
        {
            Equipment rewardItem = null!;
            if (RandomNumbers.RandomNr.Next(0, 2) == 1)
            {
                rewardItem = GameContentSpawner.Instance.Armors[RandomNumbers.RandomNr.Next(0, GameContentSpawner.Instance.Armors.Count() - 1)];
                DisplayReward((Armor)rewardItem);
                rewardTakerInventory.InventoryList.Add(rewardItem);
            }
            else
            {
                rewardItem = GameContentSpawner.Instance.Weapons[RandomNumbers.RandomNr.Next(0, GameContentSpawner.Instance.Weapons.Count() - 1)];
                DisplayReward((Weapon)rewardItem);
                rewardTakerInventory.InventoryList.Add(rewardItem);
            }
        }
        /// <summary>
        /// Display Weapon Reward
        /// </summary>
        /// <param name="item">Weapon to be displayed</param>
        private static void DisplayReward(Weapon item)
        {
            Console.WriteLine($"Weapon Name: {item.Name}");
            Console.WriteLine($"Weapon Damage: {item.Damage}");
            Console.WriteLine($"Weapon Type: {item.WeaponType}");
            Console.WriteLine($"Weapon Slot: {item.WeaponHand}");
            Console.WriteLine($"Weapon Strength: {item.Strength}");
            Console.WriteLine($"Weapon Dexterity: {item.Dexterity}");
            Console.WriteLine($"Weapon Intelligence: {item.Intelligence}");
        }
        /// <summary>
        /// Display Armor Reward
        /// </summary>
        /// <param name="item">Armor to be displayed</param>
        private static void DisplayReward(Armor item)
        {
            Console.WriteLine($"Armor Name: {item.Name}");
            Console.WriteLine($"Armor Type: {item.ArmorType}");
            Console.WriteLine($"Armor Slot: {item.ArmorSlot}");
            Console.WriteLine($"Armor defense: {item.Defense}");
            Console.WriteLine($"Armor Strength: {item.Strength}");
            Console.WriteLine($"Armor Dexterity: {item.Dexterity}");
            Console.WriteLine($"Armor Intelligence: {item.Intelligence}");
        }
    }
}
