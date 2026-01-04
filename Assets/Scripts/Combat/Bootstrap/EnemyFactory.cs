using Combat.Behaviors;
using Combat.Contracts;
using Combat.Model;
using UnityEngine;
using Zenject;

namespace Combat.Bootstrap
{
    public enum EnemyType 
    {
        BasicMelee,
        BasicRanged,
        BasicPoison
    }
    public class EnemyFactory 
    {
        private readonly DiContainer _container;

        public EnemyFactory(DiContainer container)
        {
            _container = container;
        }

        public Enemy Create(EnemyType type, int hp)
        {
            IAttackBehavior attack = type switch
            {
                EnemyType.BasicMelee => _container.Instantiate<MeleeAttack>(),
                EnemyType.BasicRanged => _container.Instantiate<RangedAttack>(),
                EnemyType.BasicPoison => _container.Instantiate<PoisonAttack>(),
                _ => _container.Instantiate<MeleeAttack>()
            };

            IHealth health = _container.Instantiate<Health>(new object[] { hp });

            return new Enemy(attack,health);
        }
    }
}
