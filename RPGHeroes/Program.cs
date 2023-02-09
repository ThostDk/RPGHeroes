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
            List<Armor> armors = new List<Armor>();
            List<Weapon> weapons = new List<Weapon>();
            weapons = weaponFactory.CreateEquipment();
            armors = armorFactory.CreateEquipment();
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