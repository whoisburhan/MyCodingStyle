using Combat.Model;
using Combat.Presenter;
using Combat.View;
using System;
using UnityEngine;
using Zenject;

namespace Combat.Bootstrap
{
    public class Combatflow : IInitializable, IDisposable
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly IEnemyView _view;
        private readonly EnemyPresenterFactory _presenterFactory;

        private EnemyPresenter _presenter;

        public Combatflow(EnemyFactory enemyFactory, IEnemyView view,
            EnemyPresenterFactory presenterFactory) 
        {
            _enemyFactory = enemyFactory;
            _view = view;
            _presenterFactory = presenterFactory;
        }

        public void Initialize()
        {
            // Run time config
            Enemy enemy = _enemyFactory.Create(EnemyType.BasicRanged, 20);
            // Wire presenter
            _presenter = _presenterFactory.Create(enemy, _view);
            //_presenter = new EnemyPresenter(enemy, _view);

            Debug.Log("Pressed A = Attack, H = Take Damage(3)");
        }
        public void Dispose()
        {
            _presenter?.Dispose();
        }
    }
}