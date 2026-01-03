using Combat.Behaviors;
using Combat.Contracts;
using UnityEngine;

namespace Combat.Model
{
    public class Enemy : IAttacker, IDamagable
    {
        private readonly IAttackBehavior _attcak;
        private readonly IHealth _health;

        public int Hp => _health.Current;
        public bool IsDead => _health.IsDead;

        public Enemy(IAttackBehavior attackBehavior, IHealth health)
        {
            _attcak = attackBehavior;
            _health = health;
        }

        public void Attack()
        {
            _attcak.Attack();
        }

        public void TakeDamage(int amount)
        {
            _health.TakeDamage(amount);
        }
    }

}