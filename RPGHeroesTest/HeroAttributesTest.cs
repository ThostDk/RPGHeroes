using RPGHeroes;
using Xunit.Sdk;

namespace RPGHeroesTest
{
    public class HeroAttributesTest
    {
        [Fact]
        public void HeroAttributesConstructor_InstantiateHeroAttributes_instanceObjectShouldHaveExpectedAttributes()
        {
            //Arrange
            int expectedStrength = 1;
            int expectedDexterity = 2;
            int expectedIntelligence = 3;
            int[] expected = new int[]
            {
                expectedStrength,
                expectedDexterity,
                expectedIntelligence,
            };
            //Act
            HeroAttributes testHeroAttributes = new HeroAttributes(1,2,3);
            int[] actual = new int[]
            {
                testHeroAttributes.BaseStrength,
                testHeroAttributes.BaseDexterity,
                testHeroAttributes.BaseIntelligence,
            };
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AddStatsFromEquipment_ItemStatsTransfertoHeroAttributes_HeroAttributesShouldGetEquippedItemsAttributes()
        {
            HeroAttributes testHeroAttributes = new HeroAttributes(0, 0, 0);
            //Arrange
            int expectedStrength = 2;
            int expectedDexterity = 2;
            int expectedIntelligence = 2;
            int[] expected = new int[]
            {
                expectedStrength,
                expectedDexterity,
                expectedIntelligence,
            };
            Armor testHelmet = new Armor(ArmorSlot.helmet, ArmorType.cloth, "test helmet", 1, 1, 1, 1, 1); 
            Weapon testWeapon = new Weapon(WeaponType.sword, WeaponHand.mainHand, "test sword", 1, 1, 1, 1, 1);
            Dictionary<ArmorSlot, Armor> testEquipmentArmor = new Dictionary<ArmorSlot, Armor>() { { ArmorSlot.helmet, testHelmet } };
            Dictionary<WeaponHand, Weapon> testEquipmentWeapon = new Dictionary<WeaponHand, Weapon>() { { WeaponHand.mainHand, testWeapon } };
            
            //Act
            testHeroAttributes.AddStatsFromEquipment(testEquipmentArmor, testEquipmentWeapon);
            int[] actual = new int[]
            {
                testHeroAttributes.TotalStrength,
                testHeroAttributes.TotalDexterity,
                testHeroAttributes.TotalIntelligence,
            };
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
