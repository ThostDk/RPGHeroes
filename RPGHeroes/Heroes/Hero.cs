using RPGHeroes.Exceptions;
using RPGHeroes.GameplayLoop;
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

        private Inventory _inventory = new Inventory();
        
        private List<ArmorType> _allowedArmorType = new List<ArmorType>();
        private List<WeaponType> _allowedWeaponType = new List<WeaponType>();
        private HeroAttributes _heroAttributes = new HeroAttributes(0, 0, 0);
        
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
        public HeroAttributes HeroAttributes { get => _heroAttributes; set => _heroAttributes = value; }
        public Inventory Inventory { get => _inventory; set => _inventory = value; }
        public List<Equipment> HeroInventoryList => _inventory.InventoryList;
        public Hero(string heroName, int baseStrength, int baseDexterity, int baseIntelligence, List<ArmorType> allowedArmorType, List<WeaponType> allowedWeaponType)
        {
            _heroName = heroName;
            _heroAttributes.BaseStrength = baseStrength;
            _heroAttributes.BaseDexterity = baseDexterity;
            _heroAttributes.BaseIntelligence = baseIntelligence;

            _allowedArmorType = allowedArmorType;
            _allowedWeaponType = allowedWeaponType;
            _heroAttributes.AddStatsFromEquipment(armorEquipped, weaponEquipped);

        }
        public void DeathCheck()
        {
            if (_heroAttributes.CurrentHealth <= 0) 
            { 
                IsDead = true;
                Console.WriteLine("Dead");
            }
            
        }
        public virtual float Attack(Hero target)
        {
            Console.WriteLine($"|Performing basic attack| Raw damage: {_heroAttributes.Damage} ");
            return _heroAttributes.Damage;
        }
        public virtual void TakeDamage(float damage)
        {
           
            _heroAttributes.CurrentHealth -= CombatHandler.CalculateDamage(damage, _heroAttributes.Defense);
            DeathCheck();
        }
        public void EquipItemFromInventory()
        {
            Console.WriteLine("Which item would you like to Equip?");
            Console.WriteLine("write the index number you want to equip | write 'exit' to go back");
            string choice = Console.ReadLine();
            int index = 0;
            choice.ToLower();
            if (choice != "exit")
            {
                try
                {
                    index = Int32.Parse(choice);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Could not parse the input to index number");
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("trying to equip "+ index + " : " +HeroInventoryList[index].Name);
                        EquipItem(HeroInventoryList[index]);
                    }
                    catch (InventoryIndexNotFoundException)
                    {
                        Console.WriteLine("could not find entered index", index);
                    }
                }
            }
            
            
        }
        public void EquipItem(Equipment item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item is null: ", nameof(item));
            }
            switch (item)
            {
                case Weapon:
                    EquipWeapon((Weapon)item);
                    break;
                case Armor:
                    EquipArmor((Armor)item);
                    break;
                default:
                    break;
            }
        }

        private void EquipArmor(Armor armor)
        {
            if (!_allowedArmorType.Contains(armor.ArmorType))
            {
                Console.WriteLine($"I can't Equip That armor! the armor is {armor.ArmorType} and i can only wear: ");
                foreach (ArmorType type in _allowedArmorType)
                {
                    Console.Write($"{type}, ");
                }
                Console.WriteLine();
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
                _heroAttributes.AddStatsFromEquipment(armorEquipped, weaponEquipped);
                
            }
        }
        private void EquipWeapon(Weapon weapon)
        {
            if (!_allowedWeaponType.Contains(weapon.WeaponType))
            {
                Console.WriteLine("I can't Equip That weapon!");
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
                _heroAttributes.AddStatsFromEquipment(armorEquipped, weaponEquipped);
            }
        }
        
        protected void LevelUpAttributes(int strengthIncrease, int dexterityIncrease, int intelligenceIncrease)
        {
            _level += 1;
            _heroAttributes.BaseStrength += strengthIncrease;
            _heroAttributes.BaseDexterity += dexterityIncrease;
            _heroAttributes.BaseIntelligence += intelligenceIncrease;
        }
        #region Display Stats, Weapons & Armor
        public void DisplayStats()
        {
            Console.WriteLine("*--------------------------------------------------*");
            Console.WriteLine($"{_heroName}'s stats & attributes are as follows:");
            Console.WriteLine($"Strength:----|{_heroAttributes.Strength}");
            Console.WriteLine($"Dexterity:-----|{_heroAttributes.Dexterity}");
            Console.WriteLine($"Intelligence:|{_heroAttributes.Intelligence}");
            Console.WriteLine($"Health:------|{_heroAttributes.MaxHealth}");
            Console.WriteLine($"Mana:--------|{_heroAttributes.CurrentMana}");
            Console.WriteLine($"Damage:------|{_heroAttributes.Damage}");
            Console.WriteLine($"Defense:-----|{_heroAttributes.Defense}");
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
