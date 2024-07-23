using UnityEngine;
using FourTale.TestCardGame.Characters.Rendering;

namespace FourTale.TestCardGame.Characters
{
    public class Character : ICharacter
    {
        public Fraction Fraction { get; }
        public int MaxHealth { get; }
        public int Health
        {
            get => _health;
            private set
            {
                _health = Mathf.Clamp(value, 0, MaxHealth);
                _renderer.SetHealth(_health, MaxHealth);
                if (_health <= 0)
                {
                    IsAlive = false;
                }
            }
        }
        public int Armor
        {
            get => _armor;
            set
            {
                _armor = Mathf.Max(value, 0);
                _renderer.SetArmor(_armor);
            }
        }
        public bool IsAlive
        {
            get => _isAlive;
            set
            {
                if (!_isAlive)
                {
                    return;
                }
                _isAlive = value;
                if (!value)
                {
                    _renderer.DisplayDeath();
                }
            }
        }

        private readonly ICharacterRenderer _renderer;
        private int _health;
        private int _armor;
        private bool _isAlive = true;

        public Character(Fraction fraction, int maxHealth, ICharacterRenderer renderer)
        {
            _renderer = renderer;

            Fraction = fraction;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Armor = 0;
        }

        public void OnActiveTurnStarted()
        {
            Armor = 0;
        }

        public void OnActiveTurnEnded()
        {

        }

        public void AttackOther(ICharacter target, int damageAmount)
        {
            if (!IsAlive)
            {
                return;
            }
            target.DealDamage(damageAmount);
            _renderer.DisplayAttack(damageAmount);
        }

        public void DealDamage(int amount)
        {
            if (amount < 0)
            {
                throw new System.ArgumentException("Damage amount should not be negative");
            }
            if (!IsAlive || amount == 0)
            {
                return;
            }
            var blockedDamage = Mathf.Min(amount, Armor);
            if (blockedDamage > 0)
            {
                Armor -= blockedDamage;
                amount -= blockedDamage;
                _renderer.DisplayBlockedDamage(blockedDamage);
            }
            if (amount > 0)
            {
                Health -= amount;
                _renderer.DisplayDamage(amount);
            }
        }

        public void ApplyArmor(int amount)
        {
            if (amount < 0)
            {
                throw new System.ArgumentException("Armor amount should not be negative");
            }
            if (!IsAlive || amount == 0)
            {
                return;
            }
            Armor += amount;
            _renderer.DisplayBlock(amount);
        }

        public void Heal(int amount)
        {
            if (amount < 0)
            {
                throw new System.ArgumentException("Heal amount should not be negative");
            }
            if (!IsAlive || amount == 0)
            {
                return;
            }
            Health += amount;
            _renderer.DisplayHeal(amount);
        }

        public void Dispose()
        {
            _renderer.Dispose();
        }
    }
}
