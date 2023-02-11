using RPGHeroes.Heroes;
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
        protected HeroAttributes heroAttributes = new HeroAttributes(0, 0, 0);
        
        
        protected List<Weapon> weapons = new List<Weapon>();
        protected List<Armor> armors = new List<Armor>();
        // Armor
        Dictionary<ArmorSlot, Armor> armorEquipped = new Dictionary<ArmorSlot, Armor>()
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

        

        public bool IsDead { get => _isDead; set => _isDead = value; }
        public int Level { get => _level; }
        public string HeroName { get => _heroName; }

        public Hero(string heroName, int baseStrength, int baseDexterity, int baseIntelligence, List<ArmorType> allowedArmorType, List<WeaponType> allowedWeaponType)
        {
            _heroName = heroName;
            heroAttributes.BaseStrength = baseStrength;
            heroAttributes.BaseDexterity = baseDexterity;
            heroAttributes.BaseIntelligence = baseIntelligence;

            _allowedArmorType = allowedArmorType;
            _allowedWeaponType = allowedWeaponType;
            heroAttributes.AddStatsFromEquipment(armorEquipped, weaponEquipped);


        }
        public virtual float Attack(Hero target)
        {
            Console.WriteLine($"|Performing basic attack| Raw damage: {heroAttributes.Damage} ");
            return heroAttributes.Damage;
        }
        public virtual void TakeDamage(int damage)
        {
            heroAttributes.Health -= CombatHandler.CalculateDamage(damage, heroAttributes.Defense);
            if (heroAttributes.Health <= 0) { IsDead = true; }
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
                heroAttributes.AddStatsFromEquipment(armorEquipped, weaponEquipped);
                
            }
        }
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
                heroAttributes.AddStatsFromEquipment(armorEquipped, weaponEquipped);
            }
        }
        
        protected void LevelUpAttributes(int strengthIncrease, int dexterityIncrease, int intelligenceIncrease)
        {
            _level += 1;
            heroAttributes.BaseStrength += strengthIncrease;
            heroAttributes.BaseDexterity += dexterityIncrease;
            heroAttributes.BaseIntelligence += intelligenceIncrease;
        }
        #region Display Stats, Weapons & Armor
        public void DisplayStats()
        {
            Console.WriteLine("*--------------------------------------------------*");
            Console.WriteLine($"{_heroName}'s stats & attributes are as follows:");
            Console.WriteLine($"Strength:----|{heroAttributes.Strength}");
            Console.WriteLine($"Dexterity:-----|{heroAttributes.Dexterity}");
            Console.WriteLine($"Intelligence:|{heroAttributes.Intelligence}");
            Console.WriteLine($"Health:------|{heroAttributes.Health}");
            Console.WriteLine($"Mana:--------|{heroAttributes.Mana}");
            Console.WriteLine($"Damage:------|{heroAttributes.Damage}");
            Console.WriteLine($"Defense:-----|{heroAttributes.Defense}");
            Console.WriteLine("*--------------------------------------------------*");
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
            if (weaponEquipped[WeaponHand.mainHand] != null)
            {
                Console.WriteLine($"Main Hand:-|{weaponEquipped[WeaponHand.mainHand].Name}");
            }
            if (weaponEquipped[WeaponHand.offHand] != null)
            {
                Console.WriteLine($"Off Hand:--|{weaponEquipped[WeaponHand.offHand].Name}");
            }
        }
        #endregion
    }
}
