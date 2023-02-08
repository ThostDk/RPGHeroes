using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class WeaponFactory
    {
        public List<Weapon> CreateEquipment()
        {// | WeaponType | Is2Hand? | Name | LevelReq | Attack | Intelligence | Dexterity | Strength |
            List<Weapon> weapons = new List<Weapon>(){
            new Weapon(WeaponType.staff,true,"Old Broom", 1, 3, 0, 4, 4),
            new Weapon(WeaponType.staff,true,"Wabbajack",3, 8, 13, 6, 4),
            new Weapon(WeaponType.wand,true,"Magic Wand",2, 1, 0, 0, 20)
            };
            return weapons;
        }
    }
}
