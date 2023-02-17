
namespace RPGHeroes
{
    public class WeaponFactory : EquipmentFactory
    {
        /// <summary>
        /// Method that returns a list of all the Weapons that should be created 
        /// </summary>
        /// <returns>returns a list of all the Weapons that should be created </returns>
        public override List<Equipment> CreateEquipment()
        {// | WeaponType | weaponHand | Name | LevelReq | Damage | Intelligence | Strength | Dexterity |
            List<Equipment> weapons = new List<Equipment>(){
            new Weapon(WeaponType.staff,WeaponHand.both,"Old Broom", 1, 3, 0, 4, 15),
            new Weapon(WeaponType.staff,WeaponHand.both,"Wabbajack",3, 8, 13, 6, 22),

            new Weapon(WeaponType.wand,WeaponHand.mainHand,"Magic Wand",2, 1, 0, 0, 12),

            new Weapon(WeaponType.axe,WeaponHand.both,"Gimli's Axe",3, 15, -2, 10, 2),
            new Weapon(WeaponType.axe,WeaponHand.mainHand,"Hatchet",1, 6, 1, 3, 2),
            new Weapon(WeaponType.axe,WeaponHand.offHand,"repurposed shovel",1, 4, 0, 2, 5),

            new Weapon(WeaponType.hammer,WeaponHand.both,"Wooden Club",1, 12, 0, 5, 2),
            new Weapon(WeaponType.hammer,WeaponHand.mainHand,"Mallet",2, 8, 0, 5, 2),
            new Weapon(WeaponType.hammer,WeaponHand.mainHand,"Soup spoon",0, 1, 0, 0, 0),

            new Weapon(WeaponType.dagger,WeaponHand.mainHand,"ScrewDriver",1, 7, 0, 1, 3),
            new Weapon(WeaponType.dagger,WeaponHand.offHand,"Shiv",1, 4, 0, 1, 4),

            new Weapon(WeaponType.bow,WeaponHand.both,"LongBow",1, 12, 0, 2, 5),
            new Weapon(WeaponType.bow,WeaponHand.both,"LongBow",1, 12, 0, 2, 5),

            new Weapon(WeaponType.AR15,WeaponHand.both,"Every American Gun-enthusiasts best buddy",15, 500, -10, 4, 2),
            };
            return weapons;
        }
    }
}
