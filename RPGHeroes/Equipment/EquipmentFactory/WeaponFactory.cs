using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class WeaponFactory : EquipmentFactory
    {
        public override List<Equipment> CreateEquipment()
        {// | WeaponType | Is2Hand? | Name | LevelReq | Damage | Intelligence | Strength | Dexterity |
            List<Equipment> weapons = new List<Equipment>(){
            new Weapon(WeaponType.staff,true,"Old Broom", 1, 3, 0, 4, 4),
            new Weapon(WeaponType.staff,true,"Wabbajack",3, 8, 13, 6, 4),
            new Weapon(WeaponType.wand,true,"Magic Wand",2, 1, 0, 0, 20),
            new Weapon(WeaponType.axe,true,"Gimli's Axe",3, 15, -2, 10, 3),
            };
            return weapons;
        }
    }
}
