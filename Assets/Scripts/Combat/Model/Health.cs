using Combat.Contracts;
using UnityEngine;

namespace Combat.Model
{
    public class Health : IHealth
    {
        public int Current { get; private set; }

        public bool IsDead => Current <= 0;

        public Health(int initialHealth)
        {
            Current = initialHealth;
        }

        public void TakeDamage(int amount)
        {
            Current -= amount;

            Debug.Log($"Took {amount} damage, current health: {Current}");

            if(Current <= 0)
            {
                Debug.Log("Entity has died.");
                Current = 0;
            }

        }
    }

}
