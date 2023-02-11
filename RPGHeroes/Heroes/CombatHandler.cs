using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public static class CombatHandler
    {
        static Random randomNr = new Random();
        static CombatHandler()
        {
            
        }
        
        public static float CalculateDamage(float attackerDamage, float defenderDefense)
        {
            double output = randomNr.NextDouble() * ((attackerDamage*1.5) - (attackerDamage*0.5)) + (attackerDamage*0.5);
            output -= defenderDefense;
            return (float)output;
        }
        
    }
}
