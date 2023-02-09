using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class ArmorFactory : EquipmentFactory
    {
        public override List<Equipment> CreateEquipment()
        {// | ArmorSlot | ArmorType | Name | LevelReq | Defense | Intelligence | Strength | Dexterity |
            List<Equipment> armor = new List<Equipment>(){
            new Armor(ArmorSlot.helmet,ArmorType.plate,"Bucket",1 , 5, 0, 0, -2),
            new Armor(ArmorSlot.bodyArmor,ArmorType.plate,"PlateKini",1 , 0, 5, 4, 10),
            new Armor(ArmorSlot.gloves,ArmorType.plate,"Rusty Gauntlet",1 , 2, 0, 3, 0),
            new Armor(ArmorSlot.pants,ArmorType.plate,"Plated Shorts",1 , 4, 0, 2, 3),
            new Armor(ArmorSlot.boots,ArmorType.plate,"Plated Boots",1 , 2, 0, 1, 1),

            new Armor(ArmorSlot.helmet,ArmorType.mail,"chainmail coif",1 , 5, 0, 0, -2),
            new Armor(ArmorSlot.bodyArmor,ArmorType.mail,"Lamellar body armor",1 , 0, 5, 4, 10),
            new Armor(ArmorSlot.gloves,ArmorType.mail,"chainmail gloves",1 , 2, 0, 3, 0),
            new Armor(ArmorSlot.pants,ArmorType.mail,"Chainmail Speedos",1 , 4, 0, 2, 3),
            new Armor(ArmorSlot.boots,ArmorType.mail,"Reinforced chain Boots",1 , 2, 0, 1, 1),

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
