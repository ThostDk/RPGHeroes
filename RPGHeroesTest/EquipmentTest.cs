using RPGHeroes;
using Xunit.Sdk;

namespace RPGHeroesTest
{
    public class EquipmentTest
    {
        [Fact]
        public void WeaponConstructor_CreateInstanceObjectForWeapon_ShouldCreateNewWeaponObjectInstanceWithGivenParameters()
        {
            //Arrange
            WeaponType expectedWeaponType = WeaponType.staff;
            WeaponHand expectedWeaponHand = WeaponHand.both;
            string expectedName = "unique test staff";
            int expectedLevelRequirement = 1;
            int expectedDamage = 2;
            int expectedIntelligence = 3;
            int expectedStrength = 4;
            int expectedDexterity = 5;

            //Act
            Weapon testWeapon = new Weapon(WeaponType.staff, WeaponHand.both, "unique test staff", 1, 2, 3, 4, 5);
            WeaponType actualWeaponType = testWeapon.WeaponType;
            WeaponHand actualWeaponHand = testWeapon.WeaponHand;
            string actualName = testWeapon.Name;
            int actualLevelRequirement = testWeapon.LevelRequirement;
            int actualDamage = testWeapon.Damage;
            int actualIntelligence = testWeapon.Intelligence;
            int actualStrength = testWeapon.Strength;
            int actualDexterity = testWeapon.Dexterity;
            //Assert
            Assert.Equal(expectedWeaponType, actualWeaponType);
            Assert.Equal(expectedWeaponHand, actualWeaponHand);
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedLevelRequirement, actualLevelRequirement);
            Assert.Equal(expectedDamage, actualDamage);
            Assert.Equal(expectedIntelligence, actualIntelligence);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
        }
        [Fact]
        public void ArmorConstructor_CreateInstanceObjectForArmor_ShouldCreateNewArmorObjectInstanceWithGivenParameters()
        {
            //Arrange
            ArmorSlot expectedArmorSlot = ArmorSlot.helmet;
            ArmorType expectedArmorType = ArmorType.plate;
            string expectedName = "unique test plate helmet";
            int expectedLevelRequirement = 1;
            int expectedDefense = 2;
            int expectedIntelligence = 3;
            int expectedStrength = 4;
            int expectedDexterity = 5;

            //Act
            Armor testArmor = new Armor(ArmorSlot.helmet, ArmorType.plate, "unique test plate helmet", 1, 2, 3, 4, 5);
            ArmorSlot actualArmorSlot = testArmor.ArmorSlot;
            ArmorType actualArmorType = testArmor.ArmorType;
            string actualName = testArmor.Name;
            int actualLevelRequirement = testArmor.LevelRequirement;
            int actualDefense = testArmor.Defense;
            int actualIntelligence = testArmor.Intelligence;
            int actualStrength = testArmor.Strength;
            int actualDexterity = testArmor.Dexterity;
            //Assert
            Assert.Equal(expectedArmorSlot, actualArmorSlot);
            Assert.Equal(expectedArmorType, actualArmorType);
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedLevelRequirement, actualLevelRequirement);
            Assert.Equal(expectedDefense, actualDefense);
            Assert.Equal(expectedIntelligence, actualIntelligence);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
        }
    }
}
