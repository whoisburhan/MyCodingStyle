using UnityEngine;

namespace Combat.Contracts
{
    public interface IDamagable
    {
        void TakeDamage(int amount);
    }
}
