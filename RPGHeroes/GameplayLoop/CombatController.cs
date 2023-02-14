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
            return (float)output;
        }
        public static void AttackHero(Enemy attacker, Hero target)
        {
            float damage = CalculateDamage(attacker.Damage, target.HeroAttributes.Defense);
            Console.WriteLine($"{attacker.Name} attacks {target.HeroName} dealing: {damage} Damage");
            Console.WriteLine();
            HeroTakeDamage(damage, target);
        }
        private static void HeroTakeDamage(float damage, Hero target)
        {
            target.HeroAttributes.CurrentHealth -= damage;
            if (target.HeroAttributes.CurrentHealth <= 0)
            {
                Console.WriteLine($"{target.HeroName} has been defeated");

            }
        }
        public static void AttackEnemy(Hero attacker, Enemy target)
        {
            float damage = CalculateDamage(attacker.HeroAttributes.Damage, target.Defense);
            Console.WriteLine($"{attacker.HeroName} attacks {target.Name} dealing: {damage} Damage");

            // Applies damage to the enemy and returns true and gives reward if the hit was lethal
            if (EnemyTakeDamage(damage, target))
            {
                target.OnDeathReward();
            }
        }
        private static bool EnemyTakeDamage(float damage, Enemy target)
        {
            target.CurrentHealth -= damage;
            if (target.CurrentHealth <= 0)
            {
                Console.WriteLine($"{target.Name} has been defeated");
                return true;
            }
            else
            {
                Console.WriteLine($"{target.Name} takes {damage} and is now on {target.CurrentHealth} health");
                return false;
            }

        }
        public static void StartCombat(Hero hero, Enemy enemy)
        {
            Console.WriteLine($"                                 (Starting combat!)");
            Console.WriteLine($"#########################|{hero.HeroName} VS {enemy.Name}|#########################");
            //while (!hero.IsDead && !enemy.IsDead)
            //{
            //    Console.WriteLine("Player's Turn:");
            //    Console.WriteLine("Enemy's Turn:");
            //}
        }
    }
}
