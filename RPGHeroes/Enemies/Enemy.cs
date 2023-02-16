using RPGHeroes.GameplayLoop;
using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class Enemy : ITakeDamage
    {
        private string _name;
        private float _currentHealth = 1;
        private float _maxHealth = 1;
        private float _mana = 1;
        private float _defense = 1;
        private float _damage = 1;
        private bool _isDead = false;
        private Inventory _inventory = new Inventory();


        public Enemy(string name, float maxHealth, float mana, float defense, float damage)
        {
            _name = name;
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
            _mana = mana;
            _defense = defense;
            _damage = damage;
        }

        public string Name { get => _name; }

        public float Mana { get => _mana; set => _mana = value; }
        public float Defense { get => _defense; }
        public float Damage { get => _damage; }
        public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public Inventory Inventory { get => _inventory; }
        public bool IsDead { get => _isDead; set => _isDead = value; }

        /// <summary>
        /// Method for Attacking the player Hero
        /// </summary>
        /// <param name="target"> The hero the enemy will damage</param>
        public void Attack(Hero target)
        {
            if (!_isDead)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                float damage = CombatController.CalculateDamage(_damage, target.HeroAttributes.Defense);
                Console.WriteLine($"{_name} attacks {target.HeroName} dealing: {damage} Damage");

                target.TakeDamage(damage);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// Method for applying damage taken to the Enemy
        /// </summary>
        /// <param name="damage">The amount of damage the enemy takes</param>
        public void TakeDamage(float damage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            _currentHealth -= damage;
            Console.WriteLine($"{_name} takes {damage} damage. {_name}'s health is now {_currentHealth} ");
            DeathCheck();
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Method for checking if enemy is dead and displaying in a positive green for the player if so.
        /// </summary>
        private void DeathCheck()
        {
            if (_currentHealth <= 0)
            {
            Console.ForegroundColor = ConsoleColor.Green;
                _isDead = true;
                Console.WriteLine($"{_name} Died!");
                OnDeathReward();
            Console.ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// Method for adding the enemy inventory content to the player hero
        /// </summary>
        /// <param name="rewardTaker">the hero target to give the reward to</param>
        public void GiveRewardFromEnemyInventory(Hero rewardTaker)
        {
            for (int i = 0; i < _inventory.InventoryList.Count; i++)
            {
                rewardTaker.Inventory.Add(_inventory.InventoryList[i]);
            }
        }

        /// <summary>
        /// Extension of the give reward method for console display
        /// </summary>
        public void OnDeathReward()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Congratulations you killed {_name}");
            Console.WriteLine($"It dropped an item for you!");
            Reward.GiveReward(Player.Hero.Inventory);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
