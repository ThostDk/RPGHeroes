using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public abstract class Equipment
    {
        protected string _name = "";
        protected int _strength = 0;
        protected int _dexterity = 0;
        protected int _intelligence = 0;
        protected int _damage = 0;
        protected int _defense = 0;
        protected int _durability = 100;
        protected int _levelRequirement = 1;
        
        public string Name { get => _name;}
        public int Strength { get => _strength;}
        public int Dexterity { get => _dexterity;}
        public int Intelligence { get => _intelligence;}
        public int Damage { get => _damage;}
        public int Defense { get => _defense;}
        public int Durability { get => _durability; set => _durability = value; }
        public int LevelRequirement { get => _levelRequirement; set => _levelRequirement = value; }

        public Equipment()
        {
            
        }

        public bool IsBroken()
        {
           return _durability <= 0 ? true : false; 
        }
    }
}
