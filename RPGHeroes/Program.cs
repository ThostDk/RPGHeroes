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
            gandalf.EquipArmor(armors[10]);
            gandalf.EquipArmor(armors[11]);
            gandalf.EquipArmor(armors[12]);
            gandalf.EquipArmor(armors[13]);
            gandalf.EquipArmor(armors[14]);
            gandalf.DisplayItems();
            gandalf.DisplayStats();
            Console.ReadLine();
        }
    }
}