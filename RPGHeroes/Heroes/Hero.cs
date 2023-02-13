﻿using RPGHeroes.Exceptions;
using RPGHeroes.GameplayLoop;
using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private Dictionary<ArmorSlot, Armor> _armorEquipped = new Dictionary<ArmorSlot, Armor>()
        {
            {ArmorSlot.helmet,null},
            {ArmorSlot.bodyArmor,null},
            {ArmorSlot.pants,null},
            {ArmorSlot.gloves,null},
            {ArmorSlot.boots,null},
        };
        // Weapons
        private Dictionary<WeaponHand, Weapon> _weaponEquipped = new Dictionary<WeaponHand, Weapon>()
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

        public Dictionary<ArmorSlot, Armor> GetArmorEquipped { get => _armorEquipped;}
        public Dictionary<WeaponHand, Weapon> GetWeaponEquipped { get => _weaponEquipped;}

        public Hero(string heroName, int baseStrength, int baseDexterity, int baseIntelligence, List<ArmorType> allowedArmorType, List<WeaponType> allowedWeaponType)
        {
            _heroName = heroName;
            _heroAttributes.BaseStrength = baseStrength;
            _heroAttributes.BaseDexterity = baseDexterity;
            _heroAttributes.BaseIntelligence = baseIntelligence;

            _allowedArmorType = allowedArmorType;
            _allowedWeaponType = allowedWeaponType;
            _heroAttributes.AddStatsFromEquipment(_armorEquipped, _weaponEquipped);

        }
        public void DeathCheck()
        {
            if (_heroAttributes.CurrentHealth <= 0)
            {
                IsDead = true;
                Console.WriteLine("Dead");
            }

        }
        public virtual float Attack(Enemy target)
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
            int index = -1;
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
                    
                        if (index < HeroInventoryList.Count && index >= 0)
                        {
                            
                            EquipItem(HeroInventoryList[index]);
                        }
                    else
                    {
                        Console.WriteLine($"could not find entered index: {index}");
                        EquipItemFromInventory();
                    }
                    
                }
            }


        }
        public void EquipItem(Equipment item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item is null: ", nameof(item));
            }
            else if (item.LevelRequirement > _level)
            {
                Console.WriteLine($"I'm too low level to equip this item | requires level {item.LevelRequirement}/ my level {_level}");
            }
            else
            {
                Console.WriteLine($"Equipping {item.Name}");
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
                        _armorEquipped[ArmorSlot.helmet] = armor;
                        break;
                    case ArmorSlot.bodyArmor:
                        _armorEquipped[ArmorSlot.bodyArmor] = armor;
                        break;
                    case ArmorSlot.gloves:
                        _armorEquipped[ArmorSlot.gloves] = armor;
                        break;
                    case ArmorSlot.pants:
                        _armorEquipped[ArmorSlot.pants] = armor;
                        break;
                    case ArmorSlot.boots:
                        _armorEquipped[ArmorSlot.boots] = armor;
                        break;
                    default:
                        break;
                }
                _heroAttributes.AddStatsFromEquipment(_armorEquipped, _weaponEquipped);

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
                        _weaponEquipped[WeaponHand.mainHand] = weapon;
                        _weaponEquipped[WeaponHand.both] = null;
                        break;
                    case WeaponHand.offHand:
                        _weaponEquipped[WeaponHand.offHand] = weapon;
                        _weaponEquipped[WeaponHand.both] = null;
                        break;
                    case WeaponHand.both:
                        _weaponEquipped[WeaponHand.both] = weapon;
                        _weaponEquipped[WeaponHand.offHand] = null;
                        _weaponEquipped[WeaponHand.mainHand] = null;
                        break;
                    default:
                        break;
                }
                _heroAttributes.AddStatsFromEquipment(_armorEquipped, _weaponEquipped);
            }
        }
        public abstract void LevelUp();
        protected void LevelUpAttributes(int strengthIncrease, int dexterityIncrease, int intelligenceIncrease)
        {
            _level += 1;
            _heroAttributes.BaseStrength += strengthIncrease;
            _heroAttributes.BaseDexterity += dexterityIncrease;
            _heroAttributes.BaseIntelligence += intelligenceIncrease;
            _heroAttributes.AddStatsFromEquipment(_armorEquipped, _weaponEquipped);
        }
        #region Display Stats, Weapons & Armor
        public void DisplayStats()
        {
            Console.WriteLine("*--------------------------------------------------*");
            Console.WriteLine($"{_heroName}'s stats & attributes are as follows:");
            Console.WriteLine($"Strength:----|{_heroAttributes.Strength}");
            Console.WriteLine($"Dexterity:---|{_heroAttributes.Dexterity}");
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
            Console.WriteLine($"Helmet:----|{DisplayArmorItem(_armorEquipped[ArmorSlot.helmet])}");
            Console.WriteLine($"Body Armor:|{DisplayArmorItem(_armorEquipped[ArmorSlot.bodyArmor])}");
            Console.WriteLine($"Gloves:----|{DisplayArmorItem(_armorEquipped[ArmorSlot.gloves])}");
            Console.WriteLine($"Pants:-----|{DisplayArmorItem(_armorEquipped[ArmorSlot.pants])}");
            Console.WriteLine($"Boots:-----|{DisplayArmorItem(_armorEquipped[ArmorSlot.boots])}");
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
            if (_weaponEquipped[WeaponHand.both] != null)
            {
                Console.WriteLine($"Both Hands:|{_weaponEquipped[WeaponHand.both].Name}");
            }
            if (_weaponEquipped[WeaponHand.mainHand] != null)
            {
                Console.WriteLine($"Main Hand:-|{_weaponEquipped[WeaponHand.mainHand].Name}");
            }
            if (_weaponEquipped[WeaponHand.offHand] != null)
            {
                Console.WriteLine($"Off Hand:--|{_weaponEquipped[WeaponHand.offHand].Name}");
            }
        }
        #endregion
    }
}
