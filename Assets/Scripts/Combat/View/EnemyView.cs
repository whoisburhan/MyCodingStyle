using System;
using UnityEngine;

namespace Combat.View
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public event Action AttackPressed;
        public event Action<int> DamageReceived;
        public void SetHP(int hp)
        {
            Debug.Log($"[View] Enemy HP set to: {hp}");
        }
        public void ShowAttack()
        {
            Debug.Log("[View] Enemy performs an attack animation.");
        }
        public void ShowDeath()
        {
            Debug.Log("[View] Enemy performs a death animation.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                OnAttackButtonPressed();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                OnDamageReceived(3);
            }
        }
        public void OnAttackButtonPressed()
        {
            AttackPressed?.Invoke();
        }
        public void OnDamageReceived(int damage)
        {
            DamageReceived?.Invoke(damage);
        }
    }

}
