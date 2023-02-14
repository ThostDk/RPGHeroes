using RPGHeroes;
using RPGHeroes.Heroes;
using Xunit.Sdk;

namespace RPGHeroesTest
{
    public class HeroClassTest
    {
        #region Mage Constructor Test
        [Fact]
        public void MageConstructor_InstantiateMage_instantObjShouldHaveMageBasicAttributes()
        {
            //Arrange
            string expectedName = "testMage";
            int expectedLevel = 1;
            List<ArmorType> expectedArmorTypes = new List<ArmorType>()
            {
                ArmorType.cloth
            };
            List<WeaponType> expectedWeaponTypes = new List<WeaponType>()
            {
                WeaponType.staff,
                WeaponType.wand
            };
            List<int> expectedAttributes = new List<int>()
            {
                1,1,8
            };
            object[] expected = new object[]
            {
                expectedName,
                expectedLevel,
                expectedAttributes,
                expectedArmorTypes,
                expectedWeaponTypes
            };

            //Assert
            Mage testMage = new Mage("testMage");
            List<ArmorType> actualArmorTypes = testMage.AllowedArmorType;
            List<WeaponType> actualWeaponTypes = testMage.AllowedWeaponType;

            List<int> actualAttributes = new List<int>()
            {
                testMage.HeroAttributes.Strength,
                testMage.HeroAttributes.Dexterity,
                testMage.HeroAttributes.Intelligence
            };
            object[] actual = new object[]
            {
                testMage.HeroName,
                testMage.Level,
                actualAttributes,
                actualArmorTypes,
                actualWeaponTypes
            };

            //Act
            Assert.Equal(expected, actual);
        }
        #endregion
        #region Barbarian Constructor Test
        [Fact]
        public void BarbarianConstructor_InstantiateBarbarian_instantObjShouldHaveMageBasicAttributes()
        {
            //Arrange
            string expectedName = "testBarbarian";
            int expectedLevel = 1;
            List<ArmorType> expectedArmorTypes = new List<ArmorType>()
            {
                ArmorType.mail,
                ArmorType.plate
            };
            List<WeaponType> expectedWeaponTypes = new List<WeaponType>()
            {
                WeaponType.axe,
                WeaponType.hammer,
                WeaponType.sword
            };
            List<int> expectedAttributes = new List<int>()
            {
                5,2,1
            };
            object[] expected = new object[]
            {
                expectedName,
                expectedLevel,
                expectedAttributes,
                expectedArmorTypes,
                expectedWeaponTypes,
            };

            //Assert
            Barbarian testBarbarian = new Barbarian("testBarbarian");
            List<ArmorType> actualArmorTypes = testBarbarian.AllowedArmorType;
            List<WeaponType> actualWeaponTypes = testBarbarian.AllowedWeaponType;

            List<int> actualAttributes = new List<int>()
            {
                testBarbarian.HeroAttributes.Strength,
                testBarbarian.HeroAttributes.Dexterity,
                testBarbarian.HeroAttributes.Intelligence
            };
            object[] actual = new object[]
            {
                testBarbarian.HeroName,
                testBarbarian.Level,
                actualAttributes,
                actualArmorTypes,
                actualWeaponTypes
            };

            //Act
            Assert.Equal(expected, actual);
        }
        #endregion
        #region Ranger Constructor Test
        [Fact]
        public void RangerConstructor_InstantiateRanger_instantObjShouldHaveMageBasicAttributes()
        {
            //Arrange
            string expectedName = "testRanger";
            int expectedLevel = 1;
            List<ArmorType> expectedArmorTypes = new List<ArmorType>()
            {
                ArmorType.leather,
                ArmorType.mail
            };
            List<WeaponType> expectedWeaponTypes = new List<WeaponType>()
            {
                WeaponType.bow,
                WeaponType.dagger
            };
            List<int> expectedAttributes = new List<int>()
            {
                1,7,1
            };
            object[] expected = new object[]
            {
                expectedName,
                expectedLevel,
                expectedAttributes,
                expectedArmorTypes,
                expectedWeaponTypes
            };

            //Assert
            Ranger testRanger = new Ranger("testRanger");
            List<ArmorType> actualArmorTypes = testRanger.AllowedArmorType;
            List<WeaponType> actualWeaponTypes = testRanger.AllowedWeaponType;

            List<int> actualAttributes = new List<int>()
            {
                testRanger.HeroAttributes.Strength,
                testRanger.HeroAttributes.Dexterity,
                testRanger.HeroAttributes.Intelligence
            };
            object[] actual = new object[]
            {
                testRanger.HeroName,
                testRanger.Level,
                actualAttributes,
                actualArmorTypes,
                actualWeaponTypes
            };

            //Act
            Assert.Equal(expected, actual);
        }
        #endregion
        #region Rogue Constructor Test
        [Fact]
        public void RogueConstructor_InstantiateRogue_instantObjShouldHaveMageBasicAttributes()
        {
            //Arrange
            string expectedName = "testRogue";
            int expectedLevel = 1;
            List<ArmorType> expectedArmorTypes = new List<ArmorType>()
            {
                ArmorType.leather,
                ArmorType.mail
            };
            List<WeaponType> expectedWeaponTypes = new List<WeaponType>()
            {
                WeaponType.dagger,
                WeaponType.sword
            };
            List<int> expectedAttributes = new List<int>()
            {
                2,6,1
            };
            object[] expected = new object[]
            {
                expectedName,
                expectedLevel,
                expectedAttributes,
                expectedArmorTypes,
                expectedWeaponTypes
            };

            //Assert
            Rogue testRogue = new Rogue("testRogue");
            List<ArmorType> actualArmorTypes = testRogue.AllowedArmorType;
            List<WeaponType> actualWeaponTypes = testRogue.AllowedWeaponType;

            List<int> actualAttributes = new List<int>()
            {
                testRogue.HeroAttributes.Strength,
                testRogue.HeroAttributes.Dexterity,
                testRogue.HeroAttributes.Intelligence,
                
            };
            object[] actual = new object[]
            {
                testRogue.HeroName,
                testRogue.Level,
                actualAttributes,
                actualArmorTypes,
                actualWeaponTypes
            };

            //Act
            Assert.Equal(expected, actual);
        }
        #endregion
        #region Mage_Level_Test
        [Fact]
        public void MageLevelUp_LevelUpCall_ShouldLevelby1()
        {
            //Arrange
            Mage testMage = new Mage("testMage");
            int expectedLevel = 2;
            //Assert
            testMage.LevelUp();
            int actualLevel = testMage.Level;

            //Act
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void MageLevelUp_LevelUpCall_AttributesincreasesByHeroTypeAmount()
        {
            //Arrange
            Mage testMage = new Mage("testMage");
            // strength|dexterity|intelligence
            List<int> expectedAttributes = new List<int>() { 2, 2, 13 };

            //Assert
            testMage.LevelUp();
            List<int> actualAttributes = new List<int>()
            {
                testMage.HeroAttributes.Strength,
                testMage.HeroAttributes.Dexterity,
                testMage.HeroAttributes.Intelligence,
            };
            
            //Act
            Assert.Equal(expectedAttributes, actualAttributes);
        }

        #endregion
        #region Barbarian_Level_Test
        [Fact]
        public void BarbarianLevelUp_LevelUpCall_ShouldLevelby1()
        {
            //Arrange
            Barbarian testBarbarian = new Barbarian("testBarbarian");
            int expectedLevel = 2;
            //Assert
            testBarbarian.LevelUp();
            int actualLevel = testBarbarian.Level;

            //Act
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void BarbarianLevelUp_LevelUpCall_AttributesincreasesByHeroTypeAmount()
        {
            //Arrange
            Barbarian testBarbarian = new Barbarian("testBarbarian");
            // strength|dexterity|intelligence
            List<int> expectedAttributes = new List<int>() { 8, 4, 2 };

            //Assert
            testBarbarian.LevelUp();
            List<int> actualAttributes = new List<int>()
            {
                testBarbarian.HeroAttributes.Strength,
                testBarbarian.HeroAttributes.Dexterity,
                testBarbarian.HeroAttributes.Intelligence,
            };

            //Act
            Assert.Equal(expectedAttributes, actualAttributes);
        }

        #endregion
        #region Ranger_Level_Test
        [Fact]
        public void RangerLevelUp_LevelUpCall_ShouldLevelby1()
        {
            //Arrange
            Ranger testRanger = new Ranger("testRanger");
            int expectedLevel = 2;
            //Assert
            testRanger.LevelUp();
            int actualLevel = testRanger.Level;

            //Act
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void RangerLevelUp_LevelUpCall_AttributesincreasesByHeroTypeAmount()
        {
            //Arrange
            Ranger testRanger = new Ranger("testRanger");
            // strength|dexterity|intelligence
            List<int> expectedAttributes = new List<int>() { 2, 12, 2 };

            //Assert
            testRanger.LevelUp();
            List<int> actualAttributes = new List<int>()
            {
                testRanger.HeroAttributes.Strength,
                testRanger.HeroAttributes.Dexterity,
                testRanger.HeroAttributes.Intelligence,
            };

            //Act
            Assert.Equal(expectedAttributes, actualAttributes);
        }

        #endregion
        #region Rogue_Level_Test
        [Fact]
        public void RogueLevelUp_LevelUpCall_ShouldLevelby1()
        {
            //Arrange
            Rogue testRogue = new Rogue("testRogue");
            int expectedLevel = 2;
            //Assert
            testRogue.LevelUp();
            int actualLevel = testRogue.Level;

            //Act
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void RogueLevelUp_LevelUpCall_AttributesincreasesByHeroTypeAmount()
        {
            //Arrange
            Rogue testRogue = new Rogue("testRogue");
            // strength|dexterity|intelligence
            List<int> expectedAttributes = new List<int>() { 3, 10, 2 };

            //Assert
            testRogue.LevelUp();
            List<int> actualAttributes = new List<int>()
            {
                testRogue.HeroAttributes.Strength,
                testRogue.HeroAttributes.Dexterity,
                testRogue.HeroAttributes.Intelligence,
            };

            //Act
            Assert.Equal(expectedAttributes, actualAttributes);
        }

        #endregion
        #region EquipItemFromInventory_Test
        //Testing the Hero Equipping logic using the Method called EquipItem
        //which then calls its sub methods for equipping weapon/armor types
        [Fact]
        public void EquipItem_EquippingListOfItems_ItemsEndsInCharacterSlots()
        {
            //Arrange
            List<Equipment> testItems = new List<Equipment>()
            {
                new Armor(ArmorSlot.helmet, ArmorType.leather, "test helmet", 1, 2, 3, 4, 5),
                new Armor(ArmorSlot.bodyArmor, ArmorType.leather, "test body", 1, 2, 3, 4, 5),
                new Armor(ArmorSlot.pants, ArmorType.leather, "test pants", 1, 2, 3, 4, 5),
                new Armor(ArmorSlot.gloves, ArmorType.leather, "test gloves", 1, 2, 3, 4, 5),
                new Armor(ArmorSlot.boots, ArmorType.leather, "test boots", 1, 2, 3, 4, 5),
                new Weapon(WeaponType.dagger, WeaponHand.mainHand,"test dagger", 1, 2, 3, 4, 5),
                new Weapon(WeaponType.sword, WeaponHand.offHand,"test sword", 1, 2, 3, 4, 5),
            };
            Rogue testRogue = new Rogue("testRogue");

            List<Equipment> expectedItemsInSlots = testItems;
            
            //Assert
            foreach (Equipment item in testItems)
            {
                testRogue.EquipItem(item);
                
            }
            List<Equipment> actualItemsInSlots = new List<Equipment>()
            {
                testRogue.GetArmorEquipped[ArmorSlot.helmet],
                testRogue.GetArmorEquipped[ArmorSlot.bodyArmor],
                testRogue.GetArmorEquipped[ArmorSlot.pants],
                testRogue.GetArmorEquipped[ArmorSlot.gloves],
                testRogue.GetArmorEquipped[ArmorSlot.boots],
                testRogue.GetWeaponEquipped[WeaponHand.mainHand],
                testRogue.GetWeaponEquipped[WeaponHand.offHand],
            };
            
            //Act
            Assert.Equivalent(expectedItemsInSlots, actualItemsInSlots);
        }
        [Fact]
        public void EquipItem_EquippingItemOfWrongLevelRequirement_ItemSlotStaysEmpty()
        {
            //Arrange

            Armor testItem = new Armor(ArmorSlot.helmet, ArmorType.leather, "test helmet", 2, 2, 3, 4, 5);
            Rogue testRogue = new Rogue("testRogue");
            Armor expectedOutcome = null;
            //Assert
            testRogue.EquipItem(testItem);
            //Act
            Assert.Equal(expectedOutcome, testRogue.GetArmorEquipped[ArmorSlot.helmet]);
        }
        [Fact]
        public void EquipItem_EquippingItemOfWrongItemType_ItemSlotStaysEmpty()
        {
            //Arrange

            Armor testItem = new Armor(ArmorSlot.helmet, ArmorType.plate, "test helmet", 1, 2, 3, 4, 5);
            Rogue testRogue = new Rogue("testRogue");
            Armor expectedOutcome = null;
            //Assert
            testRogue.EquipItem(testItem);
            //Act
            Assert.Equal(expectedOutcome, testRogue.GetArmorEquipped[ArmorSlot.helmet]);
        }
        #endregion
    }
}