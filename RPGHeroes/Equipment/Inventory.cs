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
        private List<Equipment> _inventory = new List<Equipment>();
        public Inventory() { }

        public void Add(Equipment item) { _inventory.Add(item); }
        public void DisplayInventory(List<Equipment> inventory)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"*-----------------------------(|Slot({i})|)-----------------------------*");
                switch (inventory[i])
                {
                    case Weapon:
                        DisplayWeapon((Weapon)inventory[i]);
                        break;
                    case Armor:
                        DisplayArmor((Armor)inventory[i]);
                        break;
                    default:
                        break;
                }
            }
        }
        public void DisplayWeapon(Weapon item)
        {
            Console.WriteLine("*-----------------------------(|Weapon|)-----------------------------*");
            Console.WriteLine($"Weapon name.........: {item.Name}");
            Console.WriteLine($"Weapon Damage.......: {item.Damage}");
            Console.WriteLine($"Weapon Type.........: {item.WeaponType}");
            Console.WriteLine($"Weapon Slot.........: {item.WeaponHand}");
            Console.WriteLine($"Weapon Strength.....: {item.Strength}");
            Console.WriteLine($"Weapon Dexterity....: {item.Dexterity}");
            Console.WriteLine($"Weapon Intelligence.: {item.Intelligence}");
            Console.WriteLine("*-----------------------------(|Weapon|)-----------------------------*");
        }
        public void DisplayArmor(Armor item)
        {
            Console.WriteLine("*-----------------------------(|Armor|)-----------------------------*");
            Console.WriteLine($"Armor name.........: {item.Name}");
            Console.WriteLine($"Armor Defense......: {item.Defense}");
            Console.WriteLine($"Armor Type.........: {item.ArmorType}");
            Console.WriteLine($"Armor Slot.........: {item.ArmorSlot}");
            Console.WriteLine($"Armor Strength.....: {item.Strength}");
            Console.WriteLine($"Armor Dexterity....: {item.Dexterity}");
            Console.WriteLine($"Armor Intelligence.: {item.Intelligence}");
            Console.WriteLine("*-----------------------------(|Armor|)-----------------------------*");
        }
    }
}
