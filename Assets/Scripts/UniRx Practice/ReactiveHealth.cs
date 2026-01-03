using System;
using UniRx;
using UnityEngine;

public class ReactiveHealth : MonoBehaviour
{
    public ReactiveProperty<int> Health = new ReactiveProperty<int>(100);

    private void Start()
    {
        Health.Where(hp => hp <= 0)
            .Subscribe( _ => OnDeath())
            .AddTo(this);
    }

    private void OnDeath()
    {
        Debug.Log("Character has died.");
    }

    public void TakeDamage(int damage)
    {
        Health.Value -= damage;
    }
}
