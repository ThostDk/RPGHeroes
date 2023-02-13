using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class EnemyFactory
    {
        public static List<Enemy> CreateEnemy()
        {// | ArmorSlot | ArmorType | Name | LevelReq | Defense | Intelligence | Strength | Dexterity |
            List<Enemy> enemies = new List<Enemy>()
            {
                new Enemy("Grumpy Orc", 40, 0, 8, 12),
                new Enemy("Lasse", 5000, 4100, 500, 9001),
                new Enemy("Your own shadow", 70, 0, 6, 17),
                new Enemy("Skeleton",20,0,1,10)
            };
            return enemies;
        }
    }
}