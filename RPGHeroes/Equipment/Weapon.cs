using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class Weapon : Equipment
    {
        WeaponType _weaponType;
        private bool _isTwoHand;
        public Weapon(WeaponType weaponType, bool twohand, string name, int levelRequirement,int damage, int intelligence, int strength, int dexterity)
        {
            _weaponType = weaponType;
            _isTwoHand = twohand;
            _name = name;
            _levelRequirement = levelRequirement;
            _damage = damage;
            _intelligence = intelligence;
            _strength = strength;
            _dexterity = dexterity;
        }

        public bool IsTwoHand { get => _isTwoHand;}
    }
}
