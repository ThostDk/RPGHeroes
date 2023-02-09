using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public abstract class Hero
    {
        private string _heroName;
        private bool _isDead = false;
        private int _level = 1;
        private List<ArmorType> _allowedArmorType = new List<ArmorType>();
        private List<WeaponType> _allowedWeaponType = new List<WeaponType>();
        // Fields: Attributes
        protected int _baseStrength = 0;
        protected int _baseDexterity = 0;
        protected int _baseIntelligence = 0;
        protected int _strength = 0;
        protected int _dexterity = 0;
        protected int _intelligence = 0;
        // Fields: Stats
        protected float _health = 0;
        protected float _mana = 0;
        protected float _damage = 0;
        protected int _defense = 0;

        protected List<Weapon> weapons = new List<Weapon>();
        protected List<Armor> armors = new List<Armor>();
        // Armor
        Dictionary<ArmorSlot,Armor> armorEquipped = new Dictionary<ArmorSlot, Armor>() 
        {
            {ArmorSlot.helmet,null}, 
            {ArmorSlot.bodyArmor,null}, 
            {ArmorSlot.pants,null}, 
            {ArmorSlot.gloves,null}, 
            {ArmorSlot.boots,null}, 
        };
        // Weapons
        Dictionary<WeaponHand, Weapon> weaponEquipped = new Dictionary<WeaponHand, Weapon>()
        {
            {WeaponHand.mainHand,null},
            {WeaponHand.offHand,null},
            {WeaponHand.both,null},
        };

        public virtual void EquipWeapon(Weapon weapon)
        {
            if (!_allowedWeaponType.Contains(weapon.WeaponType))
            {
                Console.WriteLine("I can't Equip That item!");
            }
            else
            {
                switch (weapon.WeaponHand)
                {
                    case WeaponHand.mainHand:
                        weaponEquipped[WeaponHand.mainHand] = weapon;
                        weaponEquipped[WeaponHand.both] = null;
                        break;
                    case WeaponHand.offHand:
                        weaponEquipped[WeaponHand.offHand] = weapon;
                        weaponEquipped[WeaponHand.both] = null;
                        break;
                    case WeaponHand.both:
                        weaponEquipped[WeaponHand.both] = weapon;
                        weaponEquipped[WeaponHand.offHand] = null;
                        weaponEquipped[WeaponHand.mainHand] = null;
                        break;
                    default:
                        break;
                }
                SetStatsFromAttributes();
            }
        }

        public bool IsDead { get => _isDead; set => _isDead = value; }
        public int Level { get => _level;}
        public string HeroName { get => _heroName;}

        public Hero(string heroName, int baseStrength, int baseDexterity, int baseIntelligence, List<ArmorType> allowedArmorType, List<WeaponType> allowedWeaponType)
        {
            _heroName = heroName;
            _baseStrength = baseStrength;
            _baseDexterity = baseDexterity;
            _baseIntelligence = baseIntelligence;
            _allowedArmorType = allowedArmorType;
            _allowedWeaponType = allowedWeaponType;
            SetStatsFromAttributes();


        }
        public virtual float Attack(Hero target)
        {
            Console.WriteLine($"|Performing basic attack| Raw damage: {_damage} ");
            return _damage;
        }
        public virtual void TakeDamage(int damage)
        {
            _health -= damage - (_defense / 2);
            if (_health <= 0) { IsDead = true; }
        }
        public virtual void EquipArmor(Armor armor)
        {
            if (!_allowedArmorType.Contains(armor.ArmorType))
            {
                Console.WriteLine("I can't Equip That item!");
            }
            else
            {
                switch (armor.ArmorSlot)
                {
                    case ArmorSlot.helmet:
                        armorEquipped[ArmorSlot.helmet] = armor;
                        break;
                    case ArmorSlot.bodyArmor:
                        armorEquipped[ArmorSlot.bodyArmor] = armor;
                        break;
                    case ArmorSlot.gloves:
                        armorEquipped[ArmorSlot.gloves] = armor;
                        break;
                    case ArmorSlot.pants:
                        armorEquipped[ArmorSlot.pants] = armor;
                        break;
                    case ArmorSlot.boots:
                        armorEquipped[ArmorSlot.boots] = armor;
                        break;
                    default:
                        break;
                }
                //ArmorSlots();
                SetStatsFromAttributes();
            }
        }

        private void SetStatsFromAttributes()
        {
            AddStatsFromEquipment();
            _health = (_baseStrength + _strength) * 5;
            _mana = (_baseIntelligence + _intelligence) * 5;
            _damage = (_baseStrength + _strength * 2) + (_baseDexterity + _dexterity * 2);
            _defense = (_baseDexterity + _dexterity) * 5;

            for (int weapon = 0; weapon < weapons.Count; weapon++)
            {
                _damage += weapons[weapon].Damage;
            }
            for (int armor = 0; armor < armors.Count; armor++)
            {
                _defense += armors[armor].Defense;
            }
            
        }
        private void AddStatsFromEquipment()
        {
            _strength = _baseStrength; _dexterity = _baseDexterity; _intelligence = _baseIntelligence; _defense = 0;
            foreach (Armor armor in armorEquipped.Values)
            {
                if(armor != null) 
                {
                    _strength += armor.Strength;
                    _dexterity += armor.Dexterity;
                    _intelligence += armor.Intelligence;
                    _defense += armor.Defense;
                }
                
            }
            foreach (Weapon weapon in weapons)
            {
                _strength += weapon.Strength;
                _dexterity += weapon.Dexterity;
                _intelligence += weapon.Intelligence;
                _damage += weapon.Damage;
            }
        }

        protected void LevelUpAttributes(int strengthIncrease, int agilityIncrease, int intelligenceIncrease)
        {
            _level += 1;
            _baseStrength += strengthIncrease;
            _baseDexterity += agilityIncrease;
            _baseIntelligence += intelligenceIncrease;
        }

        public void DisplayStats()
        {
            Console.WriteLine( "*--------------------------------------------------*");
            Console.WriteLine($"{ _heroName}'s stats & attributes are as follows:");
            Console.WriteLine($"Strength:----|{_strength}");
            Console.WriteLine($"Agility:-----|{_dexterity}");
            Console.WriteLine($"Intelligence:|{_intelligence}");
            Console.WriteLine($"Health:------|{_health}");
            Console.WriteLine($"Mana:--------|{_mana}");
            Console.WriteLine($"Damage:------|{_damage}");
            Console.WriteLine($"Defense:-----|{_defense}");
            Console.WriteLine( "*--------------------------------------------------*");
        }
        public void DisplayItems()
        {
            Console.WriteLine("*--------------------------------------------------*");
            Console.WriteLine($"{_heroName}'s Inventory is as follows:");
            Console.WriteLine($"Helmet:----|{DisplayArmorItem(armorEquipped[ArmorSlot.helmet])}");
            Console.WriteLine($"Body Armor:|{DisplayArmorItem(armorEquipped[ArmorSlot.bodyArmor])}");
            Console.WriteLine($"Gloves:----|{DisplayArmorItem(armorEquipped[ArmorSlot.gloves])}");
            Console.WriteLine($"Pants:-----|{DisplayArmorItem(armorEquipped[ArmorSlot.pants])}");
            Console.WriteLine($"Boots:-----|{DisplayArmorItem(armorEquipped[ArmorSlot.boots])}");
            DisplayWeaponItem();
            Console.WriteLine("*--------------------------------------------------*");
        }

        // Method that returns the item name if the item spot is filled  
        private string DisplayArmorItem(Equipment item)
        {   
            if (item != null)
            {
                return item.Name;
            }
            else
            {
                return "Empty";
            }
        }
        private void DisplayWeaponItem()
        {
            if (weaponEquipped[WeaponHand.both] != null)
            {
                Console.WriteLine($"Both Hands:|{weaponEquipped[WeaponHand.both].Name}");
            }
            if(weaponEquipped[WeaponHand.mainHand] != null)
            {
                Console.WriteLine($"Main Hand:-|{weaponEquipped[WeaponHand.mainHand].Name}");
            }
            if (weaponEquipped[WeaponHand.offHand] != null)
            {
                Console.WriteLine($"Off Hand:--|{weaponEquipped[WeaponHand.offHand].Name}");
            }
        }
    }
}
