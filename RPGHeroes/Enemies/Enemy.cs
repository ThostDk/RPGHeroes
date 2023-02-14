using RPGHeroes.GameplayLoop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class Enemy
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
            _mana = mana;
            _defense = defense;
            _damage = damage;
        }

        public string Name { get => _name;}
        
        public float Mana { get => _mana; set => _mana = value; }
        public float Defense { get => _defense;}
        public float Damage { get => _damage;}
        public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public Inventory Inventory { get => _inventory;}
        public bool IsDead { get => _isDead; set => _isDead = value; }

        public void GiveKillRewardFromInventory(Hero rewardTaker)
        {
                for (int i = 0; i < _inventory.InventoryList.Count; i++)
            {
                rewardTaker.Inventory.Add(_inventory.InventoryList[i]);
            }
        }
        public void OnDeathReward()
        {
            Console.WriteLine($"Congratulations you killed {_name}");
            Console.WriteLine($"It dropped a item for you!");
            Reward.GiveReward(Player.Hero.Inventory);
        }
        
    }
}
