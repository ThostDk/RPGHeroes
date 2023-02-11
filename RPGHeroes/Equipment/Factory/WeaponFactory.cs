﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public static class WeaponFactory
    {
        public static List<Weapon> CreateEquipment()
        {// | WeaponType | weaponHand | Name | LevelReq | Damage | Intelligence | Strength | Dexterity |
            List<Weapon> weapons = new List<Weapon>(){
            new Weapon(WeaponType.staff,WeaponHand.both,"Old Broom", 1, 3, 0, 4, 15),
            new Weapon(WeaponType.staff,WeaponHand.both,"Wabbajack",3, 8, 13, 6, 22),
            new Weapon(WeaponType.wand,WeaponHand.mainHand,"Magic Wand",2, 1, 0, 0, 12),
            new Weapon(WeaponType.axe,WeaponHand.both,"Gimli's Axe",3, 15, -2, 10, 36),
            };
            return weapons;
        }
    }
}