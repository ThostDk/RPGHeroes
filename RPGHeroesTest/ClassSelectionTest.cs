using RPGHeroes;
using RPGHeroes.GameplayLoop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroesTest
{
    public class ClassSelectionTest
    {
        [Fact]
        public void SelectHero_SettingHeroName_HeroNameShouldBecomeTestHero()
        {
            //Arrange
            

            string name = "testHero";
            string choice = "mage";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader("testHero\r\nmage");
            Console.SetIn(stringReader);

            //Act
            Player.Hero = ClassSelection.SelectHero();
            //Assert
            string expected = name;
            string actual = Player.Hero.HeroName;

            Assert.Equal(expected, actual);

        }
    }
}
