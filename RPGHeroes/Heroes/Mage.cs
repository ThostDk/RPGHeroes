﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class Mage : Hero
    {
        public Mage(string heroName) : base(heroName, 1, 1, 8, ArmorType.cloth)
        {
            
        }
        public override int Attack()
        {
            if (_mana > 10*Level)
            {
                return CastFireball();
            }
            Console.WriteLine($"|hitting with {WeaponSlots()}| Raw damage: {_intelligence * 2} ");
            return _damage;
        }
        public override void TakeDamage(int damage)
        {
            if (_mana > 0)
            {
                _health -= CastMagicBarrier(damage);
                if (_health <= 0) { IsDead = true; }
            }
            else
            {
                base.TakeDamage(damage);
            }
        }
        #region Spells
        private float CastMagicBarrier(int damage)
        {
            float output = 0;
            if (_mana > 0)
            {
                output = (damage - 10* Level);
                _mana -= 10* Level;
            }
            else
            {
                output = (damage - _mana);
                _mana = 0;
            }
            return output;
        }
        private int CastFireball()
        {
            Console.WriteLine($"|Casting fireball| Raw damage: {_intelligence * 2} ");
            _mana -= 10 * Level;
            return _intelligence * 2;
        }
        #endregion
        
        // just add equipment to a list and check for viable items?
        // maybe make method called EquipItem(Equipment item) that checks for existing equipment and viability?
        public override List<Weapon> WeaponSlots()
        {
            if (mainHand.IsTwoHand)
            {
                return new List<Weapon>() { mainHand };
            }
            else if (!mainHand.IsTwoHand && !offHand.IsTwoHand)
            {
                return new List<Weapon>() { mainHand, offHand };
            }
            else
            {
                return new List<Weapon>() { offHand };
            }
        }
        public override void LevelUp(int strengthIncrease, int agilityIncrease, int intelligenceIncrease)
        {
            base.LevelUp(strengthIncrease, agilityIncrease, intelligenceIncrease);

        }

    }
}
