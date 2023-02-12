using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public static class ClassSelection
    {
        public static void SelectHero()
        {
            RenderAscii.RenderChooseClass();
            List<string> HeroChoices = new List<string>() { "mage", "ranger", "barbarian", "rogue"};
            if (HeroSelectionNavigation(0, HeroChoices))
            {
                // create hero
            }

        }
        private static bool HeroSelectionNavigation(int index, List<string> heroChoices)
        {
            if(index >= heroChoices.Count) { index = 0; }
            if(index < 0) { index = heroChoices.Count-1; }
            Console.WriteLine("index: " + index);
            RenderCurrentClassOption(index);
            ConsoleKeyInfo key;
            key = Console.ReadKey();


            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    return true;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    index--;
                    HeroSelectionNavigation(index, heroChoices);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    index++;
                    HeroSelectionNavigation(index, heroChoices);
                    break;
                default:
                    HeroSelectionNavigation(index, heroChoices);
                    break;
            }
            return false;
            
        }
        private static void RenderCurrentClassOption(int index)
        {
            switch (index)
            {
                case 0:
                    RenderAscii.RenderMage();
                    break;
                case 1:
                    RenderAscii.RenderRanger();
                    break;
                case 2:
                    RenderAscii.RenderBarbarian();
                    break;
                case 3:
                    RenderAscii.RenderRogue();
                    break;
                default:
                    break;
            }
        }
    }
}
