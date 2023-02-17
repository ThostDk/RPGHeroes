
namespace RPGHeroes
{
    public static class Explore
    {
        /// <summary>
        /// Method for exploration that randomly selects a situation for the player
        /// </summary>
        public static void SearchRoom()
        {
            Console.WriteLine("You Search the current room");
            int randomSearchResult = RandomNumbers.RandomNr.Next(0, 2);
            switch (randomSearchResult)
            {
                case 0:
                    FoundChest();
                    break;
                case 1:
                    FoundEnemy();
                    break;
                default:
                    break; 
            }

        }
        /// <summary>
        /// Method that returns a reward to the player
        /// </summary>
        private static void FoundChest()
        {
            Console.WriteLine($"While searching the room you found a Chest!");
            Console.WriteLine($"Inside the chest you find a item. (Item added to your inventory)");
            Reward.GiveReward(Player.Hero.Inventory);
        }
        /// <summary>
        /// Method for starting a combat encounter with a random enemy
        /// </summary>
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
