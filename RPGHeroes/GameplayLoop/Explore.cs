using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGHeroes.GameplayLoop
{
    public static class Explore
    {
        public static void SearchRoom()
        {
            Console.WriteLine("You Search the current room");
            int randomSearchResult = RandomNumbers.RandomNr.Next(0, 3);
            Console.WriteLine("number: " +randomSearchResult);
            switch (randomSearchResult)
            {
                case 0:
                    FoundChest();
                    break;
                case 1:
                case 2:
                    FoundEnemy();
                    break;
                default:
                    break; 
            }

        }

        private static void FoundChest()
        {
            Console.WriteLine($"While searching the room you found a Chest!");
            Console.WriteLine($"Inside the chest you find a item. (Item added to your inventory)");
            Reward.GiveReward(Player.Hero.Inventory);
        }
        private static void FoundEnemy()
        {
            Console.WriteLine("OH NO! an enemy was hiding in the corner!");
            int enemyType = RandomNumbers.RandomNr.Next(0, GameContentSpawner.Instance.Enemies.Count-1);
            
            Enemy enemy = GameContentSpawner.Instance.Enemies[enemyType];
            CombatController.StartCombat(Player.Hero, enemy);
            // Reset the enemy;
            enemy.IsDead = false;
            enemy.CurrentHealth = enemy.MaxHealth;
        }

    }
}
