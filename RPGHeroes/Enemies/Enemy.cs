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

        public void GiveKillRewardFromInventory(Hero rewardTaker)
        {
                for (int i = 0; i < _inventory.InventoryList.Count; i++)
            {
                rewardTaker.Inventory.Add(_inventory.InventoryList[i]);
            }
        }
        public Equipment GiveKillReward(Hero rewardTaker)
        {
            Equipment rewardItem = null;
            if (RandomNumbers.RandomNr.Next(0, 1) == 1)
            {
                rewardItem = ArmorFactory.CreateEquipment()[RandomNumbers.RandomNr.Next(0, ArmorFactory.CreateEquipment().Count() - 1)];
                DisplayReward((Armor)rewardItem);
                rewardTaker.EquipItem(rewardItem);
            }
            else
            {
                rewardItem = WeaponFactory.CreateEquipment()[RandomNumbers.RandomNr.Next(0, WeaponFactory.CreateEquipment().Count() - 1)];
                DisplayReward((Weapon)rewardItem);
                rewardTaker.EquipItem((Weapon)rewardItem);
            }
            
            return rewardItem;
        }
        private void DisplayReward(Weapon item)
        {
            Console.WriteLine($"Congratulations you killed {_name}");
            Console.WriteLine($"It dropped a item for you: {item.Name}");
            Console.WriteLine($"Weapon Damage: {item.Damage}");
            Console.WriteLine($"Weapon Type: {item.WeaponType}");
            Console.WriteLine($"Weapon Slot: {item.WeaponHand}");
            Console.WriteLine($"Weapon Strength: {item.Strength}");
            Console.WriteLine($"Weapon Dexterity: {item.Dexterity}");
            Console.WriteLine($"Weapon Intelligence: {item.Intelligence}");

        }
        private void DisplayReward(Armor item)
        {
            Console.WriteLine($"Congratulations you killed {_name}");
            Console.WriteLine($"It dropped a item for you: {item.Name}");
            Console.WriteLine($"Armor Type: {item.ArmorType}");
            Console.WriteLine($"Armor Slot: {item.ArmorSlot}");
            Console.WriteLine($"Armor defense: {item.Defense}");
            Console.WriteLine($"Armor Strength: {item.Strength}");
            Console.WriteLine($"Armor Dexterity: {item.Dexterity}");
            Console.WriteLine($"Armor Intelligence: {item.Intelligence}");

        }
    }
}
