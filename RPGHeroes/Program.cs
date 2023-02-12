using RPGHeroes.GameplayLoop;
using RPGHeroes.Heroes;
using System.Security.Cryptography.X509Certificates;


namespace RPGHeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {   List<string> test = new List<string>() {"haha","ged","gg","h" };
            for (int i = 0; i < test.Count; i++)
            {
                string fillerRight = "||######################";
                
                Console.WriteLine(""fillerRight.PadLeft(20 - test[i].Count()));
            }
            Console.ReadLine();
            // might break on different screens!
            Console.SetWindowSize(200, 60);
            // Create all Game Items and Enemies
            List<Armor> armors = new List<Armor>();
            List<Weapon> weapons = new List<Weapon>();
            List<Enemy> enemies = new List<Enemy>();
            armors = ArmorFactory.CreateEquipment();
            weapons = WeaponFactory.CreateEquipment();
            enemies = EnemyFactory.CreateEnemy();

            // GamePlay Loop Begins
            RenderAscii.RenderBackground();
            Player.Hero = ClassSelection.SelectHero();

            //for Testing
            foreach (Armor item in armors)
            {
                Player.Hero.Inventory.Add(item);
            }
            PlayerActionsHandler.PlayerActions();
            

            

            Mage gandalf = new Mage("Gandalf");
            Ranger legolas = new Ranger("Legolas");

            //should not be able to
            legolas.EquipItem(armors[0]);
            legolas.EquipItem(armors[15]);

            legolas.EquipItem(armors[5]);
            legolas.DisplayItems();
            legolas.DisplayStats();
            legolas.EquipItem(armors[11]);
            legolas.EquipItem(armors[12]);
            legolas.EquipItem(armors[8]);
            legolas.EquipItem(armors[9]);
            legolas.DisplayItems();
            legolas.DisplayStats();
            Console.WriteLine("========================================================");
            Console.WriteLine("#####################|NEXT HERO|########################");
            Console.WriteLine("========================================================");
            gandalf.DisplayStats();
            gandalf.EquipItem(armors[1]);
            gandalf.EquipItem(armors[15]);
            gandalf.EquipItem(armors[16]);
            gandalf.EquipItem(armors[17]);
            gandalf.EquipItem(armors[18]);
            gandalf.EquipItem(armors[19]);
            gandalf.EquipItem(weapons[0]);
            gandalf.DisplayItems();
            gandalf.DisplayStats();
            gandalf.TakeDamage(500);
            Console.WriteLine("current. " + gandalf.HeroAttributes.CurrentHealth);
            Console.WriteLine("max. " + gandalf.HeroAttributes.MaxHealth);
            Console.ReadLine();
        }

        public static void CreateItems()
        {

        }
    }
}