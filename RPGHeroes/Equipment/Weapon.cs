using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class Weapon : Equipment
    {
        private WeaponType _weaponType;
        private WeaponHand _weaponHand;
        public Weapon(WeaponType weaponType, WeaponHand weaponHand, string name, int levelRequirement,int damage, int intelligence, int strength, int dexterity) : base(name, levelRequirement, strength, dexterity, intelligence, 100)
        {
            _weaponType = weaponType;
            _weaponHand = weaponHand;
            _name = name;
            _levelRequirement = levelRequirement;
            _damage = damage;
            _intelligence = intelligence;
            _strength = strength;
            _dexterity = dexterity;
        }

        public WeaponType WeaponType { get => _weaponType;}
        public WeaponHand WeaponHand { get => _weaponHand;}
    }
}
