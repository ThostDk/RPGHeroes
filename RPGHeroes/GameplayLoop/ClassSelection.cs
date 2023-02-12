using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
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
        public static Hero SelectHero()
        {
            RenderAscii.RenderChooseClass();
            List<string> HeroChoices = new List<string>() { "mage", "ranger", "barbarian", "rogue"};
            string choice = HeroSelectionNavigation(0, HeroChoices);
            {
                
                Console.WriteLine("Tell us your Hero's Name");
                string name = Console.ReadLine();
                switch (choice)
                {
                    case "mage":
                        return new Mage(name);
                    case "ranger":
                        return new Mage(name);
                    case "barbarian":
                        return new Barbarian(name);
                    case "rogue":
                        return new Rogue(name);
                    default:
                        throw new ChosenHeroNotFoundException("The selected choice doesn't exist");
                }
            }

        }
        private static string HeroSelectionNavigation(int index, List<string> heroChoices)
        {
            if(index >= heroChoices.Count) { index = 0; }
            if(index < 0) { index = heroChoices.Count-1; }
            
            RenderCurrentClassOption(index);
            ConsoleKeyInfo key;
            key = Console.ReadKey();


            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("HELLO!");
                    return heroChoices[index];
                    
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
            return heroChoices[index];
            //throw new Exception("How did you even get here?! anyways... you somehow pressed a key that neither activated any case or the default recursion call");
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
