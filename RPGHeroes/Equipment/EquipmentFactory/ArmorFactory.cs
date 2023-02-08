﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class ArmorFactory
    {
        public List<Armor> CreateEquipment()
        {// | ArmorSlot | ArmorType | Name | LevelReq | Defense | Intelligence | Dexterity | Strength |
            List<Armor> armor = new List<Armor>(){
            new Armor(ArmorSlot.helmet,ArmorType.mail,"Bucket",1 , 5, 0, 0, -2),
            new Armor(ArmorSlot.bodyArmor,ArmorType.mail,"PlateKini",1 , 0, 5, 4, 10),
            new Armor(ArmorSlot.gloves,ArmorType.mail,"Rusty Gauntlet",1 , 2, 0, 3, 0),
            new Armor(ArmorSlot.pants,ArmorType.mail,"Chainmail Shorts",1 , 4, 0, 2, 3),
            new Armor(ArmorSlot.boots,ArmorType.mail,"Plated Boots",1 , 2, 0, 1, 1),

            new Armor(ArmorSlot.helmet, ArmorType.leather,"Leather Cap",1 , 2, 1, 0, 3),
            new Armor(ArmorSlot.bodyArmor, ArmorType.leather,"Brigandine",1 , 4, 1, 2, 3),
            new Armor(ArmorSlot.gloves, ArmorType.leather,"Fur Gloves",1 , 3, 0, 2, 0),
            new Armor(ArmorSlot.pants, ArmorType.leather,"Studded Pants",1 , 2, 0, 1, 4),
            new Armor(ArmorSlot.boots, ArmorType.leather,"Sandals",1 , 1, 1, 0, 3),

            new Armor(ArmorSlot.helmet, ArmorType.cloth,"Red Hood",1 , 1, 4, 0, 4),
            new Armor(ArmorSlot.bodyArmor, ArmorType.cloth,"Gandalf's old grey Robe",1 , 2, 6, 1, 3),
            new Armor(ArmorSlot.gloves, ArmorType.cloth,"Fingerless Gloves",1 , 0, 5, 1, 0),
            new Armor(ArmorSlot.pants, ArmorType.cloth,"Pants, Just pants...",1 , 2, 3, 3, 1),
            new Armor(ArmorSlot.boots, ArmorType.cloth,"Socks",1 , 0, 3, 1, 0),
            };
            return armor;
        }
    }
}
