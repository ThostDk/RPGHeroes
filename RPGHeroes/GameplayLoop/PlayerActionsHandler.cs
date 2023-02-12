using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGHeroes.GameplayLoop
{
    public static class PlayerActionsHandler
    {


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
            List<string> playerActions = new List<string>() { "inventory", "characterStats", "explore", "exitGame" };
            string choice = PlayerActionNavigation(0, playerActions, "Options");
            switch (choice)
            {
                case "inventory":
                    Console.Clear();
                    PlayerInventoryActions();
                    Player.Hero.Inventory.DisplayInventory();
                    break;
                case "characterStats":
                    Console.Clear();
                    Player.Hero.DisplayStats();
                    Console.WriteLine(" -> press any key to go back <- ");
                    Console.ReadLine();
                    break;
                case "explore":
                    Console.Clear();
                    Console.WriteLine("I'm exploring the dungeon!");
                    //make exploration 
                    break;
                case "exitGame":
                    Exit();
                    break;
                default:
                    throw new Exception("Selected action is not an option");
            }
            PlayerActions();
        }
        public static void PlayerInventoryActions()
        {
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
                    Player.Hero.Inventory.DisplayInventory();
                    Player.Hero.EquipItemFromInventory();
                    Console.WriteLine(" -> press any key to go back <- ");
                    Console.ReadLine();
                    break;
                case "exitInventory":
                    Console.Clear();
                    PlayerActions();
                    break;
                default:
                    throw new Exception("Selected action is not an option");
            }

            PlayerInventoryActions();
        }
        public static string PlayerActionNavigation(int index, List<string> playerChoices, string menuTitle)
        {
            RenderAscii.RenderPlayerActionsMenu(playerChoices, index);
            if (index >= playerChoices.Count) { index = 0; }
            if (index < 0) { index = playerChoices.Count - 1; }

            ConsoleKeyInfo action;
            action = Console.ReadKey();


            switch (action.Key)
            {
                case ConsoleKey.Enter:
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
