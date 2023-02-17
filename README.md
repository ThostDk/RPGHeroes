# Background
RPGHeroes is an assignment from the Accelerated Learning course in Fullstack .Net developer (Noroff). The RPGHeroes .NET Console application utilizes C# 
Objectoriented programming with Inheritance and Instantiating Gameobjects along with Design patterns such as Factory and SingleTon to Reach its goal. 

# Testing
The Code has been unit tested along the development process to ensure methods run as expected and exceptions are thrown whenever something unexpected might somehow 
still happen. Each Method has been run through various scenarios with different inputs  to see if they act as expected during Assert. 

# Description
The Concole Application is a game where you can choose a hero, give it a name, equip armors and weapons that increases your stats. You can then go out and 
explore where you can be lucky to find a chest of loot to equip, or be unlucky and get ambushed by a angry enemy who will try to kill you. If you do manage
to kill the enemy, you will get a reward aswell as increase in level which will boost your base attributes. increasing in level will then Unlock new items 
for you to equip and beat your enemies with.

If you want to cheat your way through the game or maybe just test a thing or two, you can click the test level up to instantly level up or click the get all items
which will throw all existing items into your inventory for you to equip through the inventory tab.

## Choose Hero
When choosing hero you are presented with 4 options: Mage, Ranger, Rogue, Barbarian to choose between by navigating with arrowkeys and pressing space or enter to pick. when a choice has been made, you need to pick a name of atleast 3 characters. 
______________________________________________________________
The classes have different starting stat amounts:
---------------------------------------------------------------
Mage starts with:     |strength: 1|Dexterity: 1|Intelligence: 8|
Each Level Increase:  |strength:+1|Dexterity:+1|Intelligence:+5|
---------------------------------------------------------------
Ranger starts with:   |strength: 1|Dexterity: 7|Intelligence: 1|
Each Level Increase:  |strength:+1|Dexterity:+5|Intelligence:+1|
---------------------------------------------------------------
Rogue starts with:    |strength: 2|Dexterity: 6|Intelligence: 1|
Each Level Increase:  |strength:+1|Dexterity:+4|Intelligence:+1|
---------------------------------------------------------------
Barbarian starts with:|strength: 5|Dexterity: 2|Intelligence: 1|
Each Level Increase:  |strength:+3|Dexterity:+2|Intelligence:+1|
---------------------------------------------------------------
______________________________________________________________

## Gameplay Loop: Option Menu
Now that you have chosen a Hero, you'll be able to play the game. 
You are presented with a menu with following options:
![Menu1](https://user-images.githubusercontent.com/44801529/219691135-1272011a-6fc2-4e5e-ba9b-2c13279a7e3c.png)

- Inventory: Opens a second menu for inventory options
Here you can view your inventory aswell as equip different items which will affect your hero's attributes and stats. 
Note: you can only equip 1 item pr. item slot (helmet, body armor, gloves, pants, boots, main hand, off hand)
- CharacterStats lets you see your hero's stats and equipped equipment
- explore makes you search the room for treasure. 
its 50/50 wether you find a item or engage in a combat encounter with a random enemy

- test options are for easily trying out the games features. 
level up increases your level and attributes so you can better fight enemies and equip new items

- exit game prompts you with a y/n option for exiting the console application

## Gameplay Loop: Inventory Menu
![Menu2](https://user-images.githubusercontent.com/44801529/219691558-e4c3b4b7-c392-4e69-a790-dd7785f8cfe9.png)
- Display inventory writes out all your owned items for you to see. Usable items are shown in white / Unusable items in red, Equipped items are shown with green  background.
-Display equipment lets you see your character equipment slots
- equipItem Calls Display Inventory and lets your equip Index item from the inventory if it meets the level and item type requirements
- exit inventory takes you back to Option Menu

## Combat 
![Combat](https://user-images.githubusercontent.com/44801529/219695507-90c57386-f315-426c-acb2-c9cabf4e131a.png)
- Combat sets you up against a random enemy where you will fight it automatically in a turn based combat.
- If you beat the enemy, your hero will be granted a random reward as well as a level
- If you die, you'll be returned to the Character selection menu
