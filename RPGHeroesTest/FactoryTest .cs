using RPGHeroes;
using RPGHeroes.Heroes;
using Xunit.Sdk;

namespace RPGHeroesTest
{
    public class FactoryTest
    {
        [Fact]
        public void CreateEquipmentForArmor_ReturnsListOfArmors_WhenCalledShouldReturnEquipmentListWithArmors()
        {
            //Arrange
            ArmorFactory testArmorFactory = new ArmorFactory();

            List<Equipment> expected = new List<Equipment>()
            {

            new Armor(ArmorSlot.helmet,ArmorType.plate,"Bucket",1 , 5, 0, 0, -2),
            new Armor(ArmorSlot.bodyArmor,ArmorType.plate,"PlateKini",1 , 0, 5, 4, 10),
            new Armor(ArmorSlot.gloves,ArmorType.plate,"Rusty Gauntlet",1 , 2, 0, 3, 0),
            new Armor(ArmorSlot.pants,ArmorType.plate,"Plated Shorts",1 , 4, 0, 2, 3),
            new Armor(ArmorSlot.boots,ArmorType.plate,"Plated Boots",1 , 2, 0, 1, 1),
            new Armor(ArmorSlot.boots,ArmorType.plate,"Fancy Plate Boots",2 , 4, 2, 4, 3),

            new Armor(ArmorSlot.helmet,ArmorType.mail,"Mithril chainmail Hat",3 , 5, 2, 4, 5),
            new Armor(ArmorSlot.helmet,ArmorType.mail,"chainmail coif",1 , 5, 0, 0, -2),
            new Armor(ArmorSlot.bodyArmor,ArmorType.mail,"Lamellar body armor",1 , 0, 5, 4, 10),
            new Armor(ArmorSlot.gloves,ArmorType.mail,"chainmail gloves",1 , 2, 0, 3, 0),
            new Armor(ArmorSlot.pants,ArmorType.mail,"Chainmail Speedos",1 , 4, 0, 2, 3),
            new Armor(ArmorSlot.boots,ArmorType.mail,"Reinforced chain Boots",1 , 2, 0, 1, 1),

            new Armor(ArmorSlot.helmet, ArmorType.leather,"Leather Cap",1 , 2, 1, 0, 3),
            new Armor(ArmorSlot.bodyArmor, ArmorType.leather,"Brigandine",1 , 4, 1, 2, 3),
            new Armor(ArmorSlot.gloves, ArmorType.leather,"Fur Gloves",1 , 3, 0, 2, 0),
            new Armor(ArmorSlot.gloves, ArmorType.leather,"Crocodile Leather Gloves",5 , 8, 6, 9, 2),
            new Armor(ArmorSlot.pants, ArmorType.leather,"Studded Pants",1 , 2, 0, 1, 4),
            new Armor(ArmorSlot.boots, ArmorType.leather,"Sandals",1 , 1, 1, 0, 3),

            new Armor(ArmorSlot.helmet, ArmorType.cloth,"Red Hood",1 , 1, 4, 0, 4),
            new Armor(ArmorSlot.bodyArmor, ArmorType.cloth,"Gandalf's old grey Robe",1 , 2, 6, 1, 3),
            new Armor(ArmorSlot.gloves, ArmorType.cloth,"Fingerless Gloves",1 , 0, 5, 1, 0),
            new Armor(ArmorSlot.pants, ArmorType.cloth,"Pants, Just pants...",1 , 2, 3, 3, 1),
            new Armor(ArmorSlot.boots, ArmorType.cloth,"Socks",1 , 0, 3, 1, 0),
            new Armor(ArmorSlot.boots, ArmorType.cloth,"Gandalfs grey Socks",8 , 3, 2, 20, 0),
            };

            //Act
            List<Equipment> actual = testArmorFactory.CreateEquipment();

            //Assert
            Assert.Equivalent(expected, actual);
        }
        [Fact]
        public void CreateEquipmentForWeapon_ReturnsListOfWeapons_WhenCalledShouldReturnEquipmentListWithWeapons()
        {
            //Arrange
            WeaponFactory testWeaponFactory = new WeaponFactory();

            List<Equipment> expected = new List<Equipment>()
            {
            new Weapon(WeaponType.staff,WeaponHand.both,"Old Broom", 1, 3, 0, 4, 15),
            new Weapon(WeaponType.staff,WeaponHand.both,"Wabbajack",3, 8, 13, 6, 22),

            new Weapon(WeaponType.wand,WeaponHand.mainHand,"Magic Wand",2, 1, 0, 0, 12),

            new Weapon(WeaponType.axe,WeaponHand.both,"Gimli's Axe",3, 15, -2, 10, 2),
            new Weapon(WeaponType.axe,WeaponHand.mainHand,"Hatchet",1, 6, 1, 3, 2),
            new Weapon(WeaponType.axe,WeaponHand.offHand,"repurposed shovel",1, 4, 0, 2, 5),

            new Weapon(WeaponType.hammer,WeaponHand.both,"Wooden Club",1, 12, 0, 5, 2),
            new Weapon(WeaponType.hammer,WeaponHand.mainHand,"Mallet",2, 8, 0, 5, 2),
            new Weapon(WeaponType.hammer,WeaponHand.mainHand,"Soup spoon",0, 1, 0, 0, 0),

            new Weapon(WeaponType.dagger,WeaponHand.mainHand,"ScrewDriver",1, 7, 0, 1, 3),
            new Weapon(WeaponType.dagger,WeaponHand.offHand,"Shiv",1, 4, 0, 1, 4),

            new Weapon(WeaponType.bow,WeaponHand.both,"LongBow",1, 12, 0, 2, 5),
            new Weapon(WeaponType.bow,WeaponHand.both,"LongBow",1, 12, 0, 2, 5),

            new Weapon(WeaponType.AR15,WeaponHand.both,"Every American Gun-enthusiasts best buddy",15, 500, -10, 4, 2),
            };

            //Act
            List<Equipment> actual = testWeaponFactory.CreateEquipment();

            //Assert
            Assert.Equivalent(expected, actual);
        }
        [Fact]
        public void CreateEnemy_ReturnsListOfEnemies_WhenCalledShouldReturnListOfAllCreatedEnemies()
        {
            //Arrange
            EnemyFactory testEnemyFactory = new EnemyFactory();

            List<Enemy> expected = new List<Enemy>()
            {
                new Enemy("Grumpy Orc", 42, 0, 2, 10),
                new Enemy("Rat", 13, 0, 1, 4),
                new Enemy("Skeleton. Spooky", 22, 0, 0, 6),
                new Enemy("Your own shadow, stop hitting yourself", 22, 0, 1, 5),
                new Enemy("Troll", 40, 0, 5, 14),
                new Enemy("Giant Spider", 45, 0, 0, 7),
                new Enemy("Bandit", 30, 0, 3, 8),
                new Enemy("Goat... Yes just a goat", 1, 500, 0, 0),
            };

            //Act
            List<Enemy> actual = testEnemyFactory.CreateEnemy();

            //Assert
            Assert.Equivalent(expected, actual);
        }
    }
}
