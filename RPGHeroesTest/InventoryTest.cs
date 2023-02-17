using RPGHeroes;
using Xunit.Sdk;

namespace RPGHeroesTest
{
    public class InventoryTest
    {
        [Fact]
        public void EquipItemFromInventory_GetIndexItemFromInventory_ShouldReturnTheRequestedIndexItem()
        {
            //Arrange
            Armor testItem1 = new Armor(ArmorSlot.helmet, ArmorType.plate, "Bucket", 1, 5, 0, 0, -2);
            Armor testItem2 = new Armor(ArmorSlot.bodyArmor, ArmorType.plate, "PlateKini", 1, 0, 5, 4, 10);
            Armor testItem3 = new Armor(ArmorSlot.gloves, ArmorType.plate, "Rusty Gauntlet", 1, 2, 0, 3, 0);

            Inventory testInventory = new Inventory();
            testInventory.InventoryList.Add(testItem1);
            testInventory.InventoryList.Add(testItem2);
            testInventory.InventoryList.Add(testItem3);

            Equipment expected = testItem2;

            //Act
            Equipment actual = testInventory.EquipItemFromInventory(1);
            
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
