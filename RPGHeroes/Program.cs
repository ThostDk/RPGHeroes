using RPGHeroes.GameplayLoop;
using RPGHeroes.Heroes;
using System.Security.Cryptography.X509Certificates;


namespace RPGHeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetCursorPosition(0, 0);
            // GamePlay Loop Begins
            RenderAscii.RenderBackground();
            RenderAscii.RenderStartGameText();
            Player.Hero = ClassSelection.SelectHero();
            PlayerActionsController.PlayerActions();
            
            Console.ReadLine();
        }

        public static void CreateItems()
        {

        }
    }
}