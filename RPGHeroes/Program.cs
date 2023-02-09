using RPGHeroes.Heroes;
using System.Security.Cryptography.X509Certificates;

namespace RPGHeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RenderFrontPage.RenderBackground();
            //Spawning Items:
            
            ArmorFactory armorFactory = new ArmorFactory();
            WeaponFactory weaponFactory = new WeaponFactory();
            List<Equipment> tmpEquipment = new List<Equipment>();
            List<Armor> armors = new List<Armor>();
            List<Weapon> weapons = new List<Weapon>();
            tmpEquipment = armorFactory.CreateEquipment();
            foreach (Equipment e in tmpEquipment)
            {
                armors.Add((Armor)e);
            }
            tmpEquipment = weaponFactory.CreateEquipment();
            foreach (Equipment e in tmpEquipment)
            {
                weapons.Add((Weapon)e);
            }
            
            //Spawning Brave Heroes
            Mage gandalf = new Mage("Gandalf");
            
            gandalf.DisplayStats();
            gandalf.EquipArmor(armors[1]);
            gandalf.EquipArmor(armors[15]);
            gandalf.EquipArmor(armors[16]);
            gandalf.EquipArmor(armors[17]);
            gandalf.EquipArmor(armors[18]);
            gandalf.EquipArmor(armors[19]);
            gandalf.DisplayItems();
            gandalf.DisplayStats();
            Console.ReadLine();
        }
    }
}