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
        public static List<Enemy> CreateEnemy()
        {// | ArmorSlot | ArmorType | Name | LevelReq | Defense | Intelligence | Strength | Dexterity |
            List<Enemy> enemies = new List<Enemy>()
            {
                new Enemy("Grumpy Orc", 40, 0, 8, 12),
                new Enemy("Lasse", 5000, 4100, 500, 9001),
                new Enemy("Skeleton",20,0,1,10),
                new Enemy("Rat",15,0,2,8),
                
            };
            return enemies;
            //new Enemy("Your own shadow", Player.Hero.HeroAttributes.MaxHealth, Player.Hero.HeroAttributes.MaxMana, Player.Hero.HeroAttributes.Defense, Player.Hero.HeroAttributes.Damage),
        }
    }
}