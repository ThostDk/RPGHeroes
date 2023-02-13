using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class Mage : Hero
    {
        public Mage(string heroName) : base(heroName, 1, 1, 8, new List<ArmorType>{ ArmorType.cloth}, new List<WeaponType> { WeaponType.wand, WeaponType.staff})
        {
            
        }
        public override float Attack(Hero target)
        {
                return base.Attack(target);
        }
        public override void TakeDamage(float damage)
        {
                base.TakeDamage(damage);
        }
        
        public override void LevelUp()
        {
            base.LevelUpAttributes(1, 1, 5);
        }

    }
}
