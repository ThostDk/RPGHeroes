
namespace RPGHeroes
{
    public class Ranger : Hero
    {
        public Ranger(string heroName) : base(heroName, 1, 7, 1, new List<ArmorType> { ArmorType.leather, ArmorType.mail }, new List<WeaponType> { WeaponType.bow, WeaponType.dagger })
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
            base.LevelUpAttributes(1, 5, 1);
        }

    }
}
