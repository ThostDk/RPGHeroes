using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public abstract class EquipmentFactory
    {
        public abstract List <Equipment> CreateEquipment();
    }
}
