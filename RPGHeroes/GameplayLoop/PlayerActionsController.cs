
namespace RPGHeroes
{
    public static class PlayerActionsController
    {
        private static bool _testItemsAddedToInventory = false;

        private static void Exit()
        {
            Console.WriteLine("Are you sure you want to exit the application? y/n ");
            while (true)
            {
                ConsoleKeyInfo action;
                action = Console.ReadKey();
                if (action.Key == ConsoleKey.Y)
                {
                    Environment.Exit(0);
                    break;
                }
                if (action.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Returning to Game");
                    PlayerActions();
                    break;
                }
            }

        }
        public static void PlayerActions()
        {
            Console.Clear();
            List<string> playerActions = new List<string>() { "inventory", "characterStats", "explore", "Test: Level Up", "Test: Get All Items", "exitGame" };
            string choice = PlayerActionNavigation(0, playerActions, "Options");
            switch (choice)
            {
                case "inventory":
                    Console.Clear();
                    PlayerInventoryActions();
                    break;
                case "characterStats":
                    Console.Clear();
                    Player.Hero.DisplayStats();
                    Player.Hero.DisplayItems();
                    Console.WriteLine(" -> press any key to go back <- ");
                    Console.ReadLine();
                    break;
                case "explore":
                    Console.Clear();
                    Explore.SearchRoom();
                    Console.WriteLine(" -> press any key to go back <- ");
                    Console.ReadLine();
                    //make exploration 
                    break;
                case "Test: Level Up":
                    Console.Clear();
                    Console.WriteLine($"Leveling up: current level is {Player.Hero.Level}");
                    Player.Hero.LevelUp();
                    Console.WriteLine($"your level is now: {Player.Hero.Level}");
                    Console.WriteLine("lets display stats");
                    Player.Hero.DisplayStats();
                    Console.WriteLine(" -> press any key to go back <- ");
                    Console.ReadLine();
                    break;
                case "Test: Get All Items":
                    Console.Clear();
                    if (!_testItemsAddedToInventory)
                    {
                        foreach (Armor item in GameContentSpawner.Instance.Armors)
                        {
                            Player.Hero.Inventory.Add(item);
                            Console.WriteLine($"|{item.Name}| has been added to your inventory");
                        }
                        foreach (Weapon item in GameContentSpawner.Instance.Weapons)
                        {
                            Player.Hero.Inventory.Add(item);
                            Console.WriteLine($"|{item.Name}| has been added to your inventory");
                        }
                        _testItemsAddedToInventory = true;
                    }
                    else { Console.WriteLine("You already have all items in the game"); }
                    Console.WriteLine(" -> press any key to go back <- ");
                    Console.ReadLine();
                    break;
                case "exitGame":
                    Exit();
                    break;
                default:
                    throw new Exception("Selected action is not an option");
            }
            
            if (!Player.Hero.IsDead) { PlayerActions(); }
            else
            {
                //Exit();
            }
            Console.Clear();
        }
        public static void PlayerInventoryActions()
        {
            bool exit = false;
            List<string> playerActions = new List<string>() { "displayInventory", "displayEquipment", "equipItem", "exitInventory" };
            string choice = PlayerActionNavigation(0, playerActions, "Inventory Menu");
            switch (choice)
            {
                case "displayInventory":
                    Console.Clear();
                    Player.Hero.Inventory.DisplayInventory();
                    Console.WriteLine(" -> press any key to go back <- ");
                    Console.ReadLine();
                    break;
                case "displayEquipment":
                    Console.Clear();
                    Player.Hero.DisplayItems();
                    Console.WriteLine(" -> press any key to go back <- ");
                    Console.ReadLine();
                    break;
                case "equipItem":
                    Console.Clear();
                    
                    CaseEquipItemFromInventory();
                    break;
                case "exitInventory":
                    Console.Clear();
                    exit = true;
                    break;
                default:
                    throw new Exception("Selected action is not an option");
            }
            
            if (!exit)
            {
                PlayerInventoryActions();
            }
        }
        private static void CaseEquipItemFromInventory()
        {
            string choice = "";
            while (choice != "exit")
            {
                Console.Clear();
                Player.Hero.Inventory.DisplayInventory();
                Equipment? item = null;
                Console.WriteLine("Which item would you like to Equip?");
                Console.Write("write the Index number you want to equip"); Console.ForegroundColor = ConsoleColor.Red;  Console.WriteLine(" | write 'exit' to go back"); Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine()!;
                choice?.ToLower();
                int index = -1;
                if (choice == "exit")
                {
                    return;
                }
                try
                {
                    index = Int32.Parse(choice!);
                    item = Player.Hero.Inventory.EquipItemFromInventory(index);
                }
                catch (FormatException)
                {

                    Console.WriteLine("Could not parse the input to index number");
                }
                finally
                {
                    if (item != null)
                    {
                        Player.Hero.EquipItem(item);
                    }
                }
            }
        }
        public static string PlayerActionNavigation(int index, List<string> playerChoices, string menuTitle)
        {
            RenderAscii.RenderPlayerActionsMenu(menuTitle, playerChoices, index, true);
            if (index >= playerChoices.Count) { index = 0; }
            if (index < 0) { index = playerChoices.Count - 1; }
            ConsoleKeyInfo action;
            action = Console.ReadKey();

            switch (action.Key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    return playerChoices[index];
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    index--;
                    return PlayerActionNavigation(index, playerChoices, menuTitle);

                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    index++;
                    return PlayerActionNavigation(index, playerChoices, menuTitle);

                default:
                    return PlayerActionNavigation(index, playerChoices, menuTitle);

            }
            throw new Exception("How did you even get here?! anyways... you somehow pressed a key that neither activated any case or the default recursion call");


        }
    }
}
