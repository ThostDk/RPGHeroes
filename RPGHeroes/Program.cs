using RPGHeroes.GameplayLoop;
using RPGHeroes.Heroes;
using System.Security.Cryptography.X509Certificates;


namespace RPGHeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // might break on different screens!
            
            // Create all Game Items and Enemies
            List<Armor> armors = new List<Armor>();
            List<Weapon> weapons = new List<Weapon>();
            List<Enemy> enemies = new List<Enemy>();
            armors = ArmorFactory.CreateEquipment();
            weapons = WeaponFactory.CreateEquipment();
            enemies = EnemyFactory.CreateEnemy();

            // GamePlay Loop Begins
            RenderAscii.RenderBackground();
            RenderAscii.RenderStartGameText();
            Player.Hero = ClassSelection.SelectHero();

            //for Testing
            foreach (Armor item in armors)
            {
                Player.Hero.Inventory.Add(item);
            }
            foreach (Weapon item in weapons)
            {
                Player.Hero.Inventory.Add(item);
            }
            PlayerActionsHandler.PlayerActions();
            
            Console.ReadLine();
        }

        public static void CreateItems()
        {

        }
    }
}