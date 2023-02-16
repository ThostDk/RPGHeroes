using RPGHeroes;
using RPGHeroes.Heroes;
using Xunit.Sdk;
namespace RPGHeroesTest
{
    public class CombatControllerTest
    {
        [Fact]
        public void CalculateDamage_()
        {
            //Arrange
            float inputDamage = 1;
            float expectedLow = 0.5f;
            float expectedHigh = 1.5f;
            float actual = 0;

            //Act
            actual = CombatController.CalculateDamage(inputDamage, 0);

            //Assert
            Assert.InRange(actual, expectedLow, expectedHigh);
            
        }
    }
}
