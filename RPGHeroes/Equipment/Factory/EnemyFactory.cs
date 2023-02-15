using RPGHeroes.GameplayLoop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class EnemyFactory
    {
        public List<Enemy> CreateEnemy()
        {// | Name | Health | Mana | Defense | Damage |
            List<Enemy> enemies = new List<Enemy>()
            {
                new Enemy("Grumpy Orc", 42, 0, 2, 10),
                new Enemy("Rat", 13, 0, 1, 4),
                new Enemy("Skeleton. Spooky", 22, 0, 0, 6),
                new Enemy("Your own shadow, stop hitting yourself", 22, 0, 1, 5),
                new Enemy("Troll", 40, 0, 5, 14),
                new Enemy("Giant Spider", 45, 0, 0, 7),
                new Enemy("Bandit", 30, 0, 3, 8),
                new Enemy("Goat... Yes just a goat", 1, 500, 0, 0),
                
            };
            return enemies;
        }
    }
}