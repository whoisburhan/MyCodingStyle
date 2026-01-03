using System;
using UnityEngine;

namespace Combat.View
{
    public interface IEnemyView
    {
        event Action AttackPressed;
        event Action<int> DamageReceived;

        void SetHP(int hp);
        void ShowAttack();
        void ShowDeath();
    }
}

