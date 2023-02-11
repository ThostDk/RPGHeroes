using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class HeroAttributes
    {
        private int _baseStrength = 0;
        private int _baseDexterity = 0;
        private int _baseIntelligence = 0;
        private int _strength = 0;
        private int _dexterity = 0;
        private int _intelligence = 0;

        private float _health = 0;
        private float _mana = 0;
        private float _defense = 0;
        private float _damage = 1;
        public HeroAttributes(int baseStrength, int baseDexterity, int baseIntelligence)
        {
            _baseStrength = baseStrength;
            _baseDexterity = baseDexterity;
            _baseIntelligence = baseIntelligence;

        }

        public int BaseStrength { get => _baseStrength; set => _baseStrength = value; }
        public int BaseDexterity { get => _baseDexterity; set => _baseDexterity = value; }
        public int BaseIntelligence { get => _baseIntelligence; set => _baseIntelligence = value; }
        public int Strength { get => _strength;}
        public int Dexterity { get => _dexterity;}
        public int Intelligence { get => _intelligence;}
        public float Health { get => _health; set => _health = value; }
        public float Mana { get => _mana; set => _mana = value; }
        public float Defense { get => _defense;}
        public float Damage { get => _damage;}

        public void AddStatsFromEquipment(Dictionary<ArmorSlot, Armor> armorEquipped, Dictionary<WeaponHand, Weapon> weaponEquipped)
        {
            _strength = _baseStrength; _dexterity = _baseDexterity; _intelligence = _baseIntelligence; _defense = 0;  _damage = 1;
            foreach (Armor armor in armorEquipped.Values)
            {
                if (armor != null)
                {
                    _strength += armor.Strength;
                    _dexterity += armor.Dexterity;
                    _intelligence += armor.Intelligence;
                    _defense += armor.Defense;
                }

            }
            foreach (Weapon weapon in weaponEquipped.Values)
            {
                if (weapon != null)
                {
                    _strength += weapon.Strength;
                    _dexterity += weapon.Dexterity;
                    _intelligence += weapon.Intelligence;
                    _damage += weapon.Damage;
                }
            }
            _health = _strength * 10;
            _mana = _intelligence * 10;
            _defense += _dexterity * 0.1f;
        }
        //private void SetStatsFromAttributes(Dictionary<ArmorSlot, Armor> armorEquipped, Dictionary<WeaponHand, Weapon> weaponEquipped)
        //{

        //    _health = (_baseStrength + _strength) * 5;
        //    _mana = (_baseIntelligence + _intelligence) * 5;
        //    _damage = (_baseStrength + _strength * 2) + (_baseDexterity + _dexterity * 2);
        //    _defense = (_baseDexterity + _dexterity) * 5;
            
        //    foreach (Weapon weapon in weaponEquipped.Values)
        //    {
        //        if (weapon != null) 
        //        {
        //            _damage += weapon.Damage;
        //        }
        //    }
        //    foreach (Armor armor in armorEquipped.Values)
        //    {
        //        if (armor != null)
        //        {
        //            _defense += armor.Defense;
        //        }
        //    }
        //}
        
    }
}
