
namespace RPGHeroes
{
    public static class ClassSelection
    {
        /// <summary>
        /// Method for selecting the Players Hero Character
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ChosenHeroNotFoundException">custom exception for if the users selection is invalid</exception>
        public static Hero SelectHero()
        {
            RenderAscii.RenderBackground();
            RenderAscii.RenderChooseClass();

            List<string> HeroChoices = new List<string>() { "mage", "ranger", "barbarian", "rogue" };
            string choice = HeroSelectionNavigation(0, HeroChoices);
            RenderAscii.RenderNameBook();
            Console.WriteLine("Tell us your Hero's Name: (Minimum 3 Characters)");
            string name = Console.ReadLine()!;
            while (name!.Length < 3)
            {
               name = Console.ReadLine()!;
            }
            switch (choice)
            {
                case "mage":
                    return new Mage(name);
                case "ranger":
                    return new Ranger(name);
                case "barbarian":
                    return new Barbarian(name);
                case "rogue":
                    return new Rogue(name);
                default:
                    throw new ChosenHeroNotFoundException("The selected Hero choice doesn't exist");
            }

        }
        /// <summary>
        /// Private Navigation Method for moving selection by reading user keystrokes and returning string of hero choice for SelectHero to read  
        /// </summary>
        /// <param name="index"></param>
        /// <param name="heroChoices"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string HeroSelectionNavigation(int index, List<string> heroChoices)
        {
            
            if (index >= heroChoices.Count) { index = 0; }
            if (index < 0) { index = heroChoices.Count - 1; }
            RenderCurrentClassOption(index);
            RenderAscii.RenderPlayerActionsMenu("class Selection", heroChoices, index, false);
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            Console.Clear();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    return heroChoices[index];

                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    index-=1;
                    return HeroSelectionNavigation(index, heroChoices);
                    
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    index += 1;
                    return HeroSelectionNavigation(index, heroChoices);
                    
                default:
                    return HeroSelectionNavigation(index, heroChoices);
                    
            }
            throw new Exception("How did you even get here?! anyways... you somehow pressed a key that neither activated any case or the default recursion call");
        }

        /// <summary>
        /// displays the selection menu and its '-> selection'  
        /// </summary>
        /// <param name="index"></param>
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
