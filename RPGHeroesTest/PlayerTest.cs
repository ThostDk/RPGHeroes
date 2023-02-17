using RPGHeroes;
using Xunit;

namespace RPGHeroesTest
{
    public class PlayerTest
    {
        [Fact]
        public void AddHero_InsertingHeroNull_ShouldThrowCustomExceptionForHeroNotFound()
        {
            //Arrange
            Hero hero = null;
            //Act
            //Assert
            Assert.Throws<ChosenHeroNotFoundException>(() => Player.AddHero(hero));
        }
        [Fact]
        public void AddHero_InsertingHeroMage_ShouldSetThePlayerHeroToTheMage()
        {
            //Arrange
            Mage expectedHero = new Mage("testHeroMage");
            //Act
            Player.AddHero(expectedHero);
            //Assert
            Assert.Equivalent(expectedHero, Player.Hero);
        }
    }
}
