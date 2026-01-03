using UnityEngine;

namespace Combat.Behaviors
{
    public class MeleeAttack : IAttackBehavior
    {
        public void Attack()
        {
            Debug.Log("Performing a melee attack!");
        }
    }
}