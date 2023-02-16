using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    internal interface ITakeDamage
    {
        public abstract void TakeDamage(float damage);
    }
}
