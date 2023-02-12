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
            
            List<string> playerActions = new List<string>() { "inventory", "explore", "exitGame" };
            string choice = PlayerActionNavigation(0, playerActions);
                switch (choice)
            {
                case "inventory":
                    PlayerInventoryActions();
                    Player.Hero.Inventory.DisplayInventory();
                    break;
                case "explore":
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
            List<string> slayerActions = new List<string>() { "displayInventory","displayEquipment", "equipItem", "exitInventory" };
            string choice = PlayerActionNavigation(0, slayerActions);
            Console.Clear();
            switch (choice)
            {
                case "displayInventory":
                    Player.Hero.Inventory.DisplayInventory();
                    break;
                case "displayEquipment":
                    Player.Hero.DisplayItems();
                    break;
                case "equipItem":
                    Player.Hero.EquipItemFromInventory();
                    break;
                case "exitInventory":
                    PlayerActions();
                    break;
                default:
                    throw new Exception("Selected action is not an option");
            }
            PlayerInventoryActions();
        }
        public static string PlayerActionNavigation(int index, List<string> playerChoices)
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
                    PlayerActionNavigation(index, playerChoices);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    index++;
                    PlayerActionNavigation(index, playerChoices);
                    break;
                default:
                    PlayerActionNavigation(index, playerChoices);
                    break;
            }
            throw new Exception("How did you even get here?! anyways... you somehow pressed a key that neither activated any case or the default recursion call");
        }
    }
}
