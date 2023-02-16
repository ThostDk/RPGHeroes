using RPGHeroes.GameplayLoop;
using RPGHeroes.Heroes;
using System.Security.Cryptography.X509Certificates;


namespace RPGHeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // GamePlay Loop Begins
            while (true)
            {
                RenderAscii.RenderBackground();
                Console.ReadLine();
                RenderAscii.RenderStartGameText();
                Player.Hero = ClassSelection.SelectHero();
                if (!Player.Hero.IsDead)
                {
                    PlayerActionsController.PlayerActions();
                }
            }
        }

    }
}