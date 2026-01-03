using UnityEngine;

namespace Combat.Behaviors
{
    public class RangedAttack : IAttackBehavior
    {
        public void Attack()
        {
            Debug.Log("Performing a ranged attack!");
        }
    }
}