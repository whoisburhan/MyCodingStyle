using UnityEngine;

namespace Combat.Behaviors
{
    public class PoisonAttack : IAttackBehavior
    {
        public void Attack()
        {
            Debug.Log("Performing a poison attack!");
        }
    }
}
