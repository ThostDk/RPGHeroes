using RPGHeroes;
using RPGHeroes.GameplayLoop;
using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroesTest
{
    public class EnemyTest
    {
        [Fact]
        public void EnemyConstructor_InstantiateEnemy_instantObjShouldHaveParameterStats()
        {
            //Arrange
            string expectedName = "testEnemy";
            float expectedMaxHealth = 1;
            float expectedMana = 2;
            float expectedDefense = 3;
            float expectedDamage = 4;
            
            object[] expected = new object[]
            {
                expectedName,
                expectedMaxHealth,
                expectedMana,
                expectedDefense,
                expectedDamage
            };

            //Act
            Enemy testEnemy = new Enemy("testEnemy", 1, 2, 3, 4);
            
            
            object[] actual = new object[]
            {
                testEnemy.Name,
                testEnemy.MaxHealth,
                testEnemy.Mana,
                testEnemy.Defense,
                testEnemy.Damage
            };

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AttackHero_AttackingHero_HeroShouldLoseCalculatedDamageInHealth()
        {
            //Arrange
            Enemy testEnemy = new Enemy("testEnemyAttacker", 10, 0, 0, 10);
            Mage testMage = new Mage("heroDefender");
            testEnemy.AttackHero(testMage);

            //Act
            float expectedMinimum = 4.8f;
            float expectedMaximum = 15;
            float actual = testMage.HeroAttributes.MaxHealth - testMage.HeroAttributes.CurrentHealth;
            //Assert
            Assert.InRange(actual, expectedMinimum, expectedMaximum);

        }
        //[fact]
        //public void takedamage_takedamagefromheroattack_enemyshouldlosecalculateddamage()
        //{
        //    //arrange
        //    enemy testenemy = new enemy("testenemyattacker", 10, 0, 0, 1);
        //    //act
        //    testenemy.takedamage(5);
        //    //assert
        //    assert.equal();

        //}
    }
}
