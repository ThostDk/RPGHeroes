using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGHeroes
{
    public class Armor : Equipment
    {
        private ArmorType _armorType;
        private ArmorSlot _armorSlot;
        public Armor(ArmorSlot armorSlot, ArmorType armorType, string name, int levelRequirement, int defense, int intelligence, int strength, int dexterity) : base(name, levelRequirement, strength, dexterity, intelligence, 100)
        {
            _armorSlot = armorSlot;
            _armorType = armorType;
            _name = name;
            _levelRequirement = levelRequirement;
            _defense = defense;
            _intelligence = intelligence;
            _strength = strength;
            _dexterity = dexterity;
        }

        public ArmorType ArmorType { get => _armorType;}
        public ArmorSlot ArmorSlot { get => _armorSlot;}
    }
}
