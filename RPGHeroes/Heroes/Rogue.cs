
namespace RPGHeroes
{
    public class Rogue : Hero
    {
        public Rogue(string heroName) : base(heroName, 2, 6, 1, new List<ArmorType> { ArmorType.leather, ArmorType.mail }, new List<WeaponType> { WeaponType.dagger, WeaponType.sword })
        {
            
        }
        public override void Attack(Enemy target)
        {
            base.Attack(target);
        }
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
        }

        public override void LevelUp()
        {
            base.LevelUpAttributes(1, 4, 1);
        }

    }
}
