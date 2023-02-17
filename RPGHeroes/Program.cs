
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
                RenderAscii.RenderStartGameText();
                Player.AddHero(ClassSelection.SelectHero());
                if (!Player.Hero.IsDead)
                {
                    PlayerActionsController.PlayerActions();
                }
            }
        }

    }
}