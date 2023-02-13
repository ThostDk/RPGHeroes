using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class Ranger : Hero
    {
        public Ranger(string heroName) : base(heroName, 1, 7, 1, new List<ArmorType> { ArmorType.leather, ArmorType.mail }, new List<WeaponType> { WeaponType.bow, WeaponType.dagger })
        {
            
        }
        public override float Attack(Enemy target)
        {
            return base.Attack(target);
        }
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
        }

        public override void LevelUp()
        {
            base.LevelUpAttributes(1, 5, 1);
        }

    }
}
