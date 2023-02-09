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
        protected Armor helmet;
        protected Armor bodyArmor;
        protected Armor pants;
        protected Armor gloves;
        protected Armor boots;
        // Weapons
        protected Weapon mainHand;
        protected Weapon offHand;

        public bool IsDead { get => _isDead; set => _isDead = value; }
        public int Level { get => _level;}
        public string HeroName { get => _heroName;}

        public Hero(string heroName, int baseStrength, int baseDexterity, int baseIntelligence, List<ArmorType> allowedArmorType)
        {
            _heroName = heroName;
            _baseStrength = baseStrength;
            _baseDexterity = baseDexterity;
            _baseIntelligence = baseIntelligence;
            _allowedArmorType = allowedArmorType;
            SetStatsFromAttributes();


        }
        public abstract float Attack();
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
                        helmet = armor;
                        break;
                    case ArmorSlot.bodyArmor:
                        bodyArmor = armor;
                        break;
                    case ArmorSlot.gloves:
                        gloves = armor;
                        break;
                    case ArmorSlot.pants:
                        pants = armor;
                        break;
                    case ArmorSlot.boots:
                        boots = armor;
                        break;
                    default:
                        break;
                }
                ArmorSlots();
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
            foreach (Armor armor in armors)
            {
                _strength += armor.Strength;
                _dexterity += armor.Dexterity;
                _intelligence +=armor.Intelligence;
                _defense += armor.Defense;
            }
            foreach (Weapon weapon in weapons)
            {
                _strength += weapon.Strength;
                _dexterity += weapon.Dexterity;
                _intelligence += weapon.Intelligence;
                _damage += weapon.Damage;
            }
            //Console.WriteLine("str:"+ _strength);
            //Console.WriteLine("dex:"+ _dexterity);
            //Console.WriteLine("int:"+ _intelligence);
            //Console.WriteLine("dmg:"+ _damage);
            //Console.WriteLine("def:"+ _defense);
        }
       
        private List<Armor> ArmorSlots()
        {
            armors = new List<Armor>() { };
            if (helmet != null){ armors.Add(helmet);}
            if (bodyArmor != null){ armors.Add(bodyArmor);}
            if (pants != null){ armors.Add(pants);}
            if (gloves != null){ armors.Add(gloves);}
            if (boots != null){ armors.Add(boots);}
            Console.WriteLine("ArmorSlots: " + armors.Count);
            return armors;
        }
        public abstract List<Weapon> WeaponSlots();

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
            Console.WriteLine($"Helmet:----|{DisplayItem(helmet)}");
            Console.WriteLine($"Body Armor:|{DisplayItem(bodyArmor)}");
            Console.WriteLine($"Gloves:----|{DisplayItem(gloves)}");
            Console.WriteLine($"Pants:-----|{DisplayItem(pants)}");
            Console.WriteLine($"Boots:-----|{DisplayItem(boots)}");
            Console.WriteLine($"Main Hand:-|{DisplayItem(mainHand)}");
            Console.WriteLine($"Off Hand:--|{DisplayItem(offHand)}");
            Console.WriteLine("*--------------------------------------------------*");
        }

        // Method that returns the item name if the item spot is filled  
        private string DisplayItem(Equipment item)
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
    }
}
