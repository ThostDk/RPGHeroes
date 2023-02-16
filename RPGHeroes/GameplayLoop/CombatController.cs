using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public static class CombatController
    {
        static Random randomNr = new Random();
        static CombatController()
        {

        }

        public static float CalculateDamage(float attackerDamage, float defenderDefense)
        {
            double output = RandomNumbers.RandomNr.NextDouble() * ((attackerDamage * 1.5) - (attackerDamage * 0.5)) + (attackerDamage * 0.5);
            output -= defenderDefense;
            output = (float)Math.Round(output, 2);
           return output < 0 ? 0f : (float)output;
        }
        
        
        
        public static void StartCombat(Hero hero, Enemy enemy)
        {
            Console.WriteLine($"                                 (Starting combat!)");
            Console.WriteLine($"#########################|{hero.HeroName} VS {enemy.Name}|#########################");
            int round = 1;
            while (!hero.IsDead && !enemy.IsDead)
            {
                Console.WriteLine($"Round: {round}");
                Console.WriteLine("Player's Turn:");
                hero.Attack(enemy);
                Console.WriteLine("Enemy's Turn:");
                enemy.Attack(hero);
                Console.WriteLine(" -> press any key to continue <- ");
                Console.ReadLine();
            }
        }
    }
}
