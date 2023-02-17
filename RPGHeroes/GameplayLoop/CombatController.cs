
namespace RPGHeroes
{

    public static class CombatController
    {
        /// <summary>
        /// Method for calculating the incoming damage which returns a random damage count of 50% to 150% of the damage
        /// </summary>
        /// <param name="attackerDamage">The raw damage stat of the attacker</param>
        /// <param name="defenderDefense">the defenders defense stat which output damage is subtracted from</param>
        /// <returns></returns>
        public static float CalculateDamage(float attackerDamage, float defenderDefense)
        {
            double output = RandomNumbers.RandomNr.NextDouble() * ((attackerDamage * 1.5) - (attackerDamage * 0.5)) + (attackerDamage * 0.5);
            output -= defenderDefense;
            output = (float)Math.Round(output, 2);
            return output < 0 ? 0f : (float)output;
        }


        /// <summary>
        /// Method for running combat gameloop between the player and a enemy
        /// </summary>
        /// <param name="hero">Players Hero</param>
        /// <param name="enemy">The Enemy The Hero is fighting</param>
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
