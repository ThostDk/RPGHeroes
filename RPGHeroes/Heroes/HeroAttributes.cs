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
        private int _totalStrength = 0;
        private int _totalDexterity = 0;
        private int _totalIntelligence = 0;

        private float _currentHealth = 1;
        private float _maxHealth = 1;
        private float _currentMana = 0;
        private float _maxMana = 0;

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
        public int TotalStrength { get => _totalStrength;}
        public int TotalDexterity { get => _totalDexterity;}
        public int TotalIntelligence { get => _totalIntelligence;}
        public float MaxHealth { get => _maxHealth;}
        public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
        public float CurrentMana { get => _currentMana; set => _currentMana = value; }
        public float Defense { get => _defense;}
        public float Damage { get => _damage;}
        public float MaxMana { get => _maxMana; set => _maxMana = value; }

        public void AddStatsFromEquipment(Dictionary<ArmorSlot, Armor> armorEquipped, Dictionary<WeaponHand, Weapon> weaponEquipped)
        {
            _totalStrength = _baseStrength; _totalDexterity = _baseDexterity; _totalIntelligence = _baseIntelligence; _defense = 0;  _damage = 1;
            foreach (Armor armor in armorEquipped.Values)
            {
                if (armor != null)
                {
                    _totalStrength += armor.Strength;
                    _totalDexterity += armor.Dexterity;
                    _totalIntelligence += armor.Intelligence;
                    _defense += armor.Defense;
                }

            }
            foreach (Weapon weapon in weaponEquipped.Values)
            {
                if (weapon != null)
                {
                    _totalStrength += weapon.Strength;
                    _totalDexterity += weapon.Dexterity;
                    _totalIntelligence += weapon.Intelligence;
                    _damage += weapon.Damage;
                }
            }
            _maxHealth = _totalStrength * 20;
            _currentHealth = MaxHealth;
            _maxMana = _totalIntelligence * 10;
            _currentMana = _maxMana;
            _defense += _totalDexterity * 0.2f;
        }
    }
}
