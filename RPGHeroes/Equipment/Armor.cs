
namespace RPGHeroes
{
    public class Armor : Equipment
    {
        private ArmorType _armorType;
        private ArmorSlot _armorSlot;
        public Armor(ArmorSlot armorSlot, ArmorType armorType, string name, int levelRequirement, int defense, int intelligence, int strength, int dexterity)
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
