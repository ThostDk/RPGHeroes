using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class Barbarian : Hero
    {
        public Barbarian(string heroName) : base(heroName, 5, 2, 1, new List<ArmorType>{ ArmorType.mail, ArmorType.plate}, new List<WeaponType> { WeaponType.axe, WeaponType.hammer, WeaponType.sword})
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
        
        public void LevelUp()
        {
            base.LevelUpAttributes(3, 2, 1);
        }

    }
}
