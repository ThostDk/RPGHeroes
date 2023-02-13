using RPGHeroes;
using RPGHeroes.Heroes;

namespace RPGHeroesTest
{
    public class HeroClassTest
    {
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
    }
}