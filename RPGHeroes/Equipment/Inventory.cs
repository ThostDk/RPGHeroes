﻿using RPGHeroes.GameplayLoop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGHeroes
{
    public class Inventory
    {
        private List<Equipment> _inventoryList = new List<Equipment>();

        public List<Equipment> InventoryList { get => _inventoryList; set => _inventoryList = value; }

        public Inventory() { }

        public void Add(Equipment item) { _inventoryList.Add(item); }
        public void DisplayInventory()
        {
            if (_inventoryList.Count <= 0)
            {
                Console.WriteLine("*----------------------------->  Your inventory is empty :(  <-----------------------------*");
            }
            for (int i = 0; i < _inventoryList.Count; i++)
            {
                Console.WriteLine($"*-----------------------------(|Inventory Slot Index({i})|)-----------------------------*");
                switch (_inventoryList[i])
                {
                    case Weapon:
                        DisplayWeapon((Weapon)_inventoryList[i]);
                        break;
                    case Armor:
                        DisplayArmor((Armor)_inventoryList[i]);
                        break;
                    default:
                        break;
                }
            }
        }
        public Equipment EquipItemFromInventory(int index)
        {
            Equipment? outputItem = null;
            if (index < _inventoryList.Count && index >= 0)
            {
                outputItem = _inventoryList[index];
            }
            else
            {
                Console.WriteLine($"could not find entered index: {index}");
            }
            return outputItem;
        }
        public void DisplayWeapon(Weapon item)
        {
            if(!Player.Hero.AllowedWeaponType.Contains(item.WeaponType) || Player.Hero.Level < item.LevelRequirement){ Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine("                                         |Weapon|                                         ");
            Console.WriteLine($"Weapon name.........: {item.Name}");
            Console.WriteLine($"Level Requirement...: {item.LevelRequirement}");
            Console.WriteLine($"Weapon Damage.......: {item.Damage}");
            Console.WriteLine($"Weapon Type.........: {item.WeaponType}");
            Console.WriteLine($"Weapon Slot.........: {item.WeaponHand}");
            Console.WriteLine($"Weapon Strength.....: {item.Strength}");
            Console.WriteLine($"Weapon Dexterity....: {item.Dexterity}");
            Console.WriteLine($"Weapon Intelligence.: {item.Intelligence}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void DisplayArmor(Armor item)
        {
            if (!Player.Hero.AllowedArmorType.Contains(item.ArmorType) || Player.Hero.Level < item.LevelRequirement) { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine("                                         |Armor|                                          ");
            Console.WriteLine($"Armor name.........: {item.Name}");
            Console.WriteLine($"Level Requirement..: {item.LevelRequirement}");
            Console.WriteLine($"Armor Defense......: {item.Defense}");
            Console.WriteLine($"Armor Type.........: {item.ArmorType}");
            Console.WriteLine($"Armor Slot.........: {item.ArmorSlot}");
            Console.WriteLine($"Armor Strength.....: {item.Strength}");
            Console.WriteLine($"Armor Dexterity....: {item.Dexterity}");
            Console.WriteLine($"Armor Intelligence.: {item.Intelligence}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
