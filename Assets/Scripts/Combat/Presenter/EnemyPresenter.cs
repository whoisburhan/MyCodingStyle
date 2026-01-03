using Combat.Model;
using Combat.View;
using UnityEngine;

public class EnemyPresenter
{
    private readonly Enemy _enemy;
    private readonly IEnemyView _view;

    public EnemyPresenter(Enemy enemy, IEnemyView view)
    {
        _enemy = enemy;
        _view = view;

        _view.AttackPressed += OnAttackPrsessed;
        _view.DamageReceived += OnDamageReceived;

        //initial Sync
        _view.SetHP(_enemy.Hp);
    }

    private void OnAttackPrsessed()
    {
        if(_enemy.IsDead)
            return;

        _enemy.Attack();
        _view.ShowAttack();
    }

    private void OnDamageReceived(int damage)
    {
        if(_enemy.IsDead)
            return;
        _enemy.TakeDamage(damage);
        _view.SetHP(_enemy.Hp);
        if(_enemy.IsDead)
        {
            _view.ShowDeath();
        }
    }

    public void Dispose() 
    {
        _view.AttackPressed -= OnAttackPrsessed;
        _view.DamageReceived -= OnDamageReceived;
    }
}
