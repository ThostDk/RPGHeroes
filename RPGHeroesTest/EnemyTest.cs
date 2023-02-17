using RPGHeroes;
using Xunit;

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
            testEnemy.Attack(testMage);

            //Act
            float expectedMinimum = 4.8f;
            float expectedMaximum = 15;
            float actual = testMage.HeroAttributes.MaxHealth - testMage.HeroAttributes.CurrentHealth;
            //Assert
            Assert.InRange(actual, expectedMinimum, expectedMaximum);

        }
        [Fact]
        public void takedamage_takedamagefromheroattack_enemyshouldlosecalculateddamage()
        {
            //arrange
            Enemy testenemy = new Enemy("testenemyHurt", 10, 0, 0, 1);
            float expected = 5;
            //act
            testenemy.TakeDamage(5);
            float actual = testenemy.MaxHealth - testenemy.CurrentHealth;
            //assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GiveRewardFromInventory_GivingRewardFromInventory_PlayerHeroGetsTheReward()
        {
            //arrange
            Mage testMage = new Mage("testMageTaker");
            Enemy testenemy = new Enemy("testenemyGiver", 1, 1, 1, 1);
            Weapon testWeapon = new Weapon(WeaponType.staff, WeaponHand.both, "unique test staff", 1, 2, 3, 4, 5);
            Armor testArmor = new Armor(ArmorSlot.helmet, ArmorType.plate, "unique test plate helmet", 1, 2, 3, 4, 5);
            List<Equipment> expected = new List<Equipment>() { testWeapon, testArmor };
            testenemy.Inventory.Add(testWeapon);
            testenemy.Inventory.Add(testArmor);
            
            //act
            testenemy.GiveRewardFromEnemyInventory(testMage);

            List<Equipment> actual = testMage.HeroInventoryList;
            
            //assert
            Assert.Equivalent(expected, actual);

        }
        [Fact]
        public void OnDeathReward_GivingRandomReward_PlayerHeroGetsARandomItem()
        {
            //arrange
            Mage testMage = new Mage("testMageTaker");
            Enemy testenemy = new Enemy("testenemyGiver", 1, 1, 1, 1);
            Weapon testWeapon = new Weapon(WeaponType.staff, WeaponHand.both, "unique test staff", 1, 2, 3, 4, 5);
            Armor testArmor = new Armor(ArmorSlot.helmet, ArmorType.plate, "unique test plate helmet", 1, 2, 3, 4, 5);
            List<Equipment> expected = new List<Equipment>() { testWeapon, testArmor };
            testenemy.Inventory.Add(testWeapon);
            testenemy.Inventory.Add(testArmor);

            //act
            Reward.GiveReward(testMage.Inventory);
            bool actual = testMage.HeroInventoryList.Count > 0;

            //assert
            Assert.True(actual);

        }
    }
}
