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
                new Enemy("Grumpy Orc", 1, 0, 0, 12),
                
                
            };
            return enemies;
            //new Enemy("Your own shadow", Player.Hero.HeroAttributes.MaxHealth, Player.Hero.HeroAttributes.MaxMana, Player.Hero.HeroAttributes.Defense, Player.Hero.HeroAttributes.Damage),
        }
    }
}